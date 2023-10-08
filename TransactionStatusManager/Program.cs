using Presenstance;
using TransactionStatusManager;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<TransactionInfoRepo>();
    })
    .Build();

host.Run();
