using Sei.Infra.Repository;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Infra.RepositoryInterface;
using SeiEmDolares.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IProtocoloRepository, ProtocoloRepository>();
        services.AddTransient<IProtocoloNoSeiEmDolaresRepository,IProtocoloNoSeiEmDolaresRepository>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
