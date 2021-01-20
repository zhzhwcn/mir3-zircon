using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Library;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Envir;

namespace Server
{
    internal class GameService : IHostedService
    {
        private readonly ILogger<GameService> _logger;

        public GameService(ILogger<GameService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var assembly = Assembly.GetAssembly(typeof(Config));
            ConfigReader.Load(assembly);
            Config.LoadVersion();

            SEnvir.LogAction = s => _logger.LogInformation(s);

            SEnvir.UseLogConsole = true;
            SEnvir.StartServer();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            SEnvir.Started = false;
            while (SEnvir.EnvirThread != null)
            {
                await Task.Delay(5);
            }
            if(ConfigReader.ConfigObjects.Count > 0) ConfigReader.Save(typeof(Config).Assembly);
        }
    }
}
