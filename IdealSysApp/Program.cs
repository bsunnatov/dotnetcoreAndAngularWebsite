using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace IdealSysApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging(f => f.AddConsole(LogLevel.Information))
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5050")
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
