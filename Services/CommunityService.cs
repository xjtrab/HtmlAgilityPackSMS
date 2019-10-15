using System;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPackSMS.Interfaces;
using HtmlAgilityPackSMS.Services;
using HtmlAgilityPack.CssSelectors.NetCore;

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
                var html = @"https://wx.5i5j.com/xiaoqu/o3/";

                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                Community community =  new Community ();
                // var nodehousetit = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[5]/div[1]/div[1]/div/span");
                // var nodeprice = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[1]/span");
                // var nodeSellHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[5]/a");
                // var nodeRentHouseCount = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/div[2]/ul/li[6]/a");
                // var nodeSeeCountRecentThirtyDays = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[2]/div[2]/ul/li[1]/div[2]/p");
                var houseNodes = htmlDoc.QuerySelectorAll("div.listCon");
                foreach (var item in houseNodes)
                {
                    community = new Community();
                    community.Name =  item.QuerySelector("h3 > a").InnerText;
                    community.Price =  int.Parse(item.QuerySelector("div > div > p.redC > strong").InnerText);
                    community.SellCount =  int.Parse(item.QuerySelector("div > div > a > p.num > span").InnerText
                        .Trim('\r').Trim('\n').Trim());
                    // community.Name =  item.QuerySelector("div > div > a > p.num > span").InnerText;
                    // community.Name =  item.QuerySelector("div > div > p.redC > strong").InnerText;
                    // community.Name =  item.QuerySelector("div > div > p.redC > strong").InnerText;
                    // community.Name =  item.QuerySelector("div > div > p.redC > strong").InnerText;
                    // community.Name =  item.QuerySelector("div > div > p.redC > strong").InnerText;
                    dbStorage.SaveCommunity(community);
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