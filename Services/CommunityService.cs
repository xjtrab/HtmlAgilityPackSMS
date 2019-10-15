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
                web.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0";
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
                    community.SellingCount =  int.Parse(item.QuerySelector("div > div > a > p.num > span").InnerText
                        .Trim('\r').Trim('\n').Trim());
                    int countIndex = item.QuerySelector("div.listCon > div > p.xqzs.clear > span").InnerText.IndexOf("\u5957");
                    if(countIndex != -1)
                    community.SelledOutLastMonth = int.Parse(item.QuerySelector("div.listCon > div > p.xqzs.clear > span").InnerText.Substring(10,countIndex - 10 - 6));    
                    int rentCountIndex = item.QuerySelector("div > p.xqzs.clear > span:nth-child(4) > a").InnerText.IndexOf("\u5957");
                    if(rentCountIndex !=-1)
                    community.RentingCount = int.Parse(item.QuerySelector("div > p.xqzs.clear > span:nth-child(4) > a").InnerText.Substring(0,rentCountIndex - 0 - 6));    

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