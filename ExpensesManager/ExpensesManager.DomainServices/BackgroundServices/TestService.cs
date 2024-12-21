using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.DomainServices.BackgroundServices
{
    public class TestService : BackgroundService
    {
        private readonly ILogger _logger;

        public TestService(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hello world! Long-running background task working!");

                await Task.Delay(3000, stoppingToken);
            }

            _logger.LogInformation("Background service stopped!");
        }
    }
}
