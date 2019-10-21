using System;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPackSMS.Interfaces;
using HtmlAgilityPackSMS.Services;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Collections.Generic;

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

                AcquisitionUnit unit = new  AcquisitionUnit();
                unit.Result = EnumAcquisitionUnit.SUCCESS;
                dbStorage.SaveAcquisitionUnit(unit);
                List<string> list = new List<string>{
                    @"https://wx.5i5j.com/xiaoqu/o3/",
                    @"https://wx.5i5j.com/xiaoqu/o3n2/"};
                list.ForEach(item =>
                {
                    Process(item,unit);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await Task.Delay(1000 * 60 * 30);
        }
    }

    private void Process(string html,AcquisitionUnit unit)
    {
        HtmlWeb web = new HtmlWeb();
        web.CaptureRedirect = false;
        web.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0";
        var htmlDoc = web.Load(html);
        Community community = new Community();
        var houseNodes = htmlDoc.QuerySelectorAll("div.listCon");
        foreach (var item in houseNodes)
        {
            community = new Community();
            community.Name = item.QuerySelector("h3 > a").InnerText;
            community.Price = int.Parse(item.QuerySelector("div > div > p.redC > strong").InnerText);
            
            var SellingCountStr = item.QuerySelector("div > div > a > p.num > span").InnerText;
            if(SellingCountStr.Contains('\r')){
               SellingCountStr = SellingCountStr.Trim('\r');
            }
            if(SellingCountStr.Contains('\n')){
               SellingCountStr = SellingCountStr.Trim('\n');
            }
            if( int.TryParse(SellingCountStr.Trim(),out int tempSellingCount)){
                community.SellingCount = tempSellingCount;
            }
            int countIndex = item.QuerySelector("div.listCon > div > p.xqzs.clear > span").InnerText.IndexOf("\u5957");
            if (countIndex != -1)
                community.SelledOutLastMonth = int.Parse(item.QuerySelector("div.listCon > div > p.xqzs.clear > span").InnerText.Substring(10, countIndex - 10 - 6));
            int rentCountIndex = item.QuerySelector("div > p.xqzs.clear > span:nth-child(4) > a").InnerText.IndexOf("\u5957");
            if (rentCountIndex != -1)
                community.RentingCount = int.Parse(item.QuerySelector("div > p.xqzs.clear > span:nth-child(4) > a").InnerText.Substring(0, rentCountIndex - 0 - 6));
            community.UnitId = unit.Id;
            dbStorage.SaveCommunity(community);
        }
    }
}