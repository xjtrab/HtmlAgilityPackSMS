using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPackSMS.DataAccess;
using HtmlAgilityPackSMS.Interfaces;
using HtmlAgilityPackSMS.Managers;
using HtmlAgilityPackSMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HtmlAgilityPackSMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Console.WriteLine(ConfigManager.Env);
            Console.WriteLine(ConfigManager.DbConnectionString);
            Console.WriteLine(ConfigManager.YunpianApikey);
            Console.WriteLine(ConfigManager.AdminEmailAccount);
            Console.WriteLine(ConfigManager.AdminEmailPassword);
            using (var context = new efContext())
            {
                context.Database.Migrate();
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IDbStorage, Dbstorage>();
            services.AddSingleton<ISMSService, YunpianSMSService>();
            services.AddSingleton<IHostedService, FangSecondHandService>();
            services.AddSingleton<IHostedService, CommunityService>();
            services.AddSingleton<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
