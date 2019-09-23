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
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await Task.Delay(1000 * 60 * 30);
        }
    }
}