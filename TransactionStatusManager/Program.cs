using Microsoft.EntityFrameworkCore;
using Presenstance;
using TransactionStatusManager;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<TransactionInfoRepo>();
        services.AddDbContext<TransasctionInfoContext>(dbOptions=> dbOptions.UseInMemoryDatabase("TransactionInfoTestDb"),  ServiceLifetime.Singleton);
    })
    .Build();

host.Run();
