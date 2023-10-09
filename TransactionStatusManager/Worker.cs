using Presenstance;

namespace TransactionStatusManager
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TransactionInfoRepo repo;

        public Worker(ILogger<Worker> logger, TransactionInfoRepo repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Getting jobs to run: {time}", DateTimeOffset.Now);
                var requestsToBeSent = await repo.GetRequestsToBeSent();

                foreach (var request in requestsToBeSent)
                {
                    request.NextSendOn = CalculateNextRun(request);
                }

                _logger.LogInformation("Worker going to sleep at: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

        private DateTime CalculateNextRun(TransactionInfo transaction)
        {
            const byte retryIntervalMultiplier = 2;
            return DateTime.Now.AddMinutes(transaction.NumberOfRetries * retryIntervalMultiplier);

        }
    }
}