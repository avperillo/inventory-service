using Inventory.Application.item;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Worker.Jobs
{
    /// <summary>
    /// Job 
    /// </summary>
    public class CheckExpirationItemJob : BackgroundService
    {
        private readonly ILogger<CheckExpirationItemJob> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly int delay;

        public CheckExpirationItemJob(
            ILogger<CheckExpirationItemJob> logger,
            IServiceProvider serviceProvider,
            IConfiguration config)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            delay = config.GetValue<int>("ExpiredItemCheckerDelay");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Job starts along with api application on start");
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"Respponse from Background Service - {DateTime.Now}");
                Dowork();
                await Task.Delay(delay, stoppingToken);
            }
        }

        private void Dowork()
        {
            using var scope = serviceProvider.CreateScope();
            var itemExpiredChecker = scope.ServiceProvider.GetRequiredService<IItemExpiredCheckerUseCase>();
            itemExpiredChecker.Check();
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
               $"{nameof(CheckExpirationItemJob)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
