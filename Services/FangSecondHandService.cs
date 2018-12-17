using System;
using System.Threading;
using System.Threading.Tasks;

namespace HtmlAgilityPackSMS.Services{
    public class FangSecondHandService : HostedService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested){
                await Task.Delay(5000);
                Console.Write("hello world");
            }
        }
    }
}