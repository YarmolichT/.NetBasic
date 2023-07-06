using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.Net;
using Serilog.Sinks.File;
using Serilog.Sinks.Email;
using Org.BouncyCastle.Crypto.Macs;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var senderEmail = "tatanayarmolich001@gmail.com";
            var password = "9U9CTat!";
            var receiverEmail = "tatanayarmolich001@gmail.com";

            Log.Logger = new LoggerConfiguration()
                             .Enrich.WithProperty("Logging", "Program")
                             .MinimumLevel.Information()
                             .WriteTo.File("Logs.json")
                             .WriteTo.Email(restrictedToMinimumLevel: LogEventLevel.Information,
                              period: TimeSpan.FromSeconds(5),
                              batchPostingLimit: 2,
                              connectionInfo: new EmailConnectionInfo
                              {
                                EmailSubject = "APP Logs",
                                NetworkCredentials = new NetworkCredential(senderEmail, password),
                                FromEmail = senderEmail,
                                ToEmail = receiverEmail,
                                MailServer = "smtp.gmail.com",
                                EnableSsl = true,
                                Port = 465
                              })            
                              .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();              
    }
}
