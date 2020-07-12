using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

// Todo: 
// 1. Add better web view (bootstrap, css) 
// 2. Streaming in signalr add 
// 3. Add parsing of presentations 
// 4. Add messaging of photos to subscribers 
// 5. Add functionality of crud for questions to presentation 
// 6. List of presentations takes too long to load, fix it!
// 7. 
// 
