using Presenstance;

namespace TransactionStatusManager
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRepo repo;

        public Worker(ILogger<Worker> logger, IRepo repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var requestsToBeSent = repo.GetToBeExecutedJobs();
                foreach (var request in requestsToBeSent)
                {
                    //Do Send Request Logic here
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}