using AasSecurity;
using AasxDatabaseServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Threading;

namespace AasxServerBlazor
{
    public class Program1
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string[] url = config["Kestrel:Endpoints:Http:Url"].Split(':');
            if (url[2] != null)
                AasxServer.Program.blazorPort = url[2];

            AasxServer.Program.localDbServer = new DatabaseServer(
                config["Database:Local:Host"],
                Int32.Parse(config["Database:Local:Port"]),
                config["Database:Local:DatabaseName"],
                config["Database:Local:Id"],
                config["Database:Local:Password"]
                );
            AasxServer.Program.cloudDbServer = new DatabaseServer(
                config["Database:Cloud:Host"],
                Int32.Parse(config["Database:Cloud:Port"]),
                config["Database:Cloud:DatabaseName"],
                config["Database:Cloud:Id"],
                config["Database:Cloud:Password"]
                );

            var host = CreateHostBuilder(args).Build();

            host.RunAsync();

            AasxServer.Program.Main(args);

            SecurityHelper.SecurityInit();

            host.WaitForShutdownAsync();

            //QuitEvent
            //HandleQuitEvent();
        }

        static void HandleQuitEvent()
        {
            ManualResetEvent quitEvent = new(false);
            try
            {
                Console.CancelKeyPress += (sender, eArgs) =>
                {
                    quitEvent.Set();
                    eArgs.Cancel = true;
                };
            }
            catch
            {
            }

            // wait for timeout or Ctrl-C
            quitEvent.WaitOne(Timeout.Infinite);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        //.UseStartup<Startup>()
                        .UseStartup<Startup>()
                        .UseUrls("http://*:5000")
                    /*
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Loopback, 5000);  // http:localhost:5000
                        options.Listen(IPAddress.Any, 80);         // http:*:80
                        options.Listen(IPAddress.Loopback, 443, listenOptions =>
                        {
                            listenOptions.UseHttps("certificate.pfx", "password");
                        });
                    })
                    */
                    ;
                });
    }
}
