using System;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPackSMS.Interfaces;
using HtmlAgilityPackSMS.Services;

public class GlobalStatusService : HostedService
{
    private readonly IDbStorage dbStorage;
    private readonly ISMSService sMSService;
    public GlobalStatusService(IDbStorage dbStorage, ISMSService sMSService)
    {
        this.dbStorage = dbStorage;
        this.sMSService = sMSService;
    }
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var html = @"https://wx.5i5j.com/ershoufang/n1/";

                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                var nodehousetit = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[5]/div[1]/div[1]/div/span");
                // var nodeprice = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[1]/span");
                // var nodeSellHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[5]/a");
                // var nodeRentHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[6]/a");
                // var nodeSeeCountRecentThirtyDays = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/ul/li[1]/div[2]/p");
                
                GlobalStatus status = new  GlobalStatus();
                status.StatusFrom = "5i5j";
                status.TotalCommunityCount  = int.Parse(nodehousetit.InnerText);
                // status.CreateTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                dbStorage.SaveGlobalStatus(status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await Task.Delay(1000 * 60 * 30);
        }
    }
}