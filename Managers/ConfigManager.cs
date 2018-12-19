using System;
using Microsoft.Extensions.Configuration;

namespace HtmlAgilityPackSMS.Managers
{
    public static class ConfigManager
    {
        public static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        public static readonly IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{Env}.json")
            .Build();
        public static string DbConnectionString  => Environment.GetEnvironmentVariable("DbConnectionString") ?? Config["DbConnectionString"];
        public static string YunpianApikey => Environment.GetEnvironmentVariable("YunpianApikey") ?? Config["YunpianApikey"];
    }
}