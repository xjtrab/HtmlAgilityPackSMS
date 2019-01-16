using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using HtmlAgilityPackSMS.Interfaces;

namespace HtmlAgilityPackSMS.Services
{
    public class FangSecondHandService : HostedService
    {
        private readonly ISMSService sMSService;
        private readonly IDbStorage dbStorage;
        public FangSecondHandService(
            ISMSService smsService,
            IDbStorage dbStorage)
        {
            this.sMSService = smsService;
            this.dbStorage = dbStorage;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                try
                {
                    var html = @"http://www.czcfang.com/house/index?sug=cm:4062";
                    HtmlWeb web = new HtmlWeb();
                    var htmlDoc = web.Load(html);
                    var node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[5]/div[1]/div/ul/li[3]/span");

                    if (node != null)
                    {
                        int totalCount = 0;
                        if (int.TryParse(node.InnerText, out totalCount))
                        {
                            //check db if exist same value record
                            SendHandListStatus status = dbStorage.GetHandListStatusLastest();
                            if (status == null)
                            {
                                sMSService.SendByPhone("13961570305", "总套数: " + totalCount);
                                dbStorage.SaveHandListStatus(new SendHandListStatus
                                {
                                    Total = totalCount,
                                    CreateTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
                                });
                            }
                            else
                            {
                                if (status.Total != totalCount)
                                {
                                    sMSService.SendByPhone("13961570305", "总套数: " + totalCount);
                                    dbStorage.SaveHandListStatus(new SendHandListStatus
                                    {
                                        Total = totalCount,
                                        CreateTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                await Task.Delay(1000 * 60 * 30);
            }
        }
    }
}