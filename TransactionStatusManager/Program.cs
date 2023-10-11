using Microsoft.EntityFrameworkCore;
using Presenstance;
using TransactionStatusManager;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<TransactionInfoRepo>();
        services.AddDbContext<TransasctionInfoContext>(dbOptions=> dbOptions.UseInMemoryDatabase("TransactionInfoTest"),  ServiceLifetime.Singleton);
        using var context = services.BuildServiceProvider().GetService<TransasctionInfoContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

    })
    .Build();

host.Run();
