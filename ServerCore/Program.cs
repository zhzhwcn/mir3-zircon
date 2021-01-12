using Autofac;
using Library;
using Microsoft.Extensions.Hosting;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.AspNetCore.Hosting;

namespace Server
{
    class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            SEnvir.Started = false;
        }
    }
}
