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
                
                var html = @"http://www.czcfang.com/house/index?sug=cm:4062";
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                var node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[5]/div[1]/div/ul/li[3]/span");
                // var test = htmlDoc.DocumentNode.QuerySelectorAll(".houseInfo");
                // foreach (var item in test)
                // {
                //     var price = item.QuerySelector(".area").QuerySelector(".gray").InnerText.Replace(Environment.NewLine, "").Trim();
                //     var totalPrice = Regex.Replace(item.QuerySelector(".area").QuerySelector(".orange").InnerText.Replace(Environment.NewLine, "").Trim(), @"\s", "");
                //     var mianji = Regex.Replace(item.QuerySelector(".horizontal").QuerySelector(".horizon-detail").InnerText.Replace(Environment.NewLine, "").Trim(), @"\s", "").Replace("&nbsp;&nbsp;", " ");

                //     var href = item.QuerySelector("a").Attributes["href"];
                //     var id = href.Value.Split("/")[3];
                //     Console.WriteLine("总价 : " + totalPrice + " 面积:" + mianji + " 单价:" + price + " id:" + id);
                //     sMSService.SendByPhone("13961570305", "总价 : " + totalPrice + " 面积:" + mianji + " id:" + id);
                //     return;
                // }
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
                                CreateTime = DateTime.Now
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
                                    CreateTime = DateTime.Now
                                });
                            }
                        }
                    }
                }
                await Task.Delay(1000 * 60 * 30);
            }
        }
    }
}