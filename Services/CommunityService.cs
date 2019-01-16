using System;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPackSMS.Interfaces;
using HtmlAgilityPackSMS.Services;

public class CommunityService : HostedService
{
    private readonly IDbStorage dbStorage;
    private readonly ISMSService sMSService;
    public CommunityService(IDbStorage dbStorage, ISMSService sMSService)
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
                var html = @"https://wx.5i5j.com/xiaoqu/348244.html";

                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                var nodehousetit = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[1]/div[1]/h1");
                var nodeprice = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[1]/span");
                var nodeSellHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[5]/a");
                var nodeRentHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[6]/a");
                var nodeSeeCountRecentThirtyDays = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/ul/li[1]/div[2]/p");

                Community community = new Community();
                community.Name = nodehousetit.InnerText;
                community.Price = decimal.Parse(nodeprice.InnerText);
                community.RentCount = int.Parse(nodeRentHouseCount.InnerText.Trim('\u5957'));
                community.SellCount = int.Parse(nodeSellHouseCount.InnerText.Trim('\u5957'));
                community.SeeCountRecentThirtyDays = int.Parse(nodeSeeCountRecentThirtyDays.InnerText.Trim('\u6B21'));
                community.CreateTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                Community dbCommunity = dbStorage.GetCommunityLastest();
                if (dbCommunity != null && (!decimal.Round(dbCommunity.Price, 0).Equals(community.Price)
                || !decimal.Round(dbCommunity.SellCount, 0).Equals(community.SellCount)))
                {
                    sMSService.SendByPhone("13961570305", $"price: {community.Price} sellCount {community.SellCount}");
                }
                dbStorage.SaveCommunity(community);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            await Task.Delay(1000 * 60 * 30);
        }
    }
}