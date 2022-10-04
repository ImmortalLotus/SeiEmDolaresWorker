using Sei.Infra.Repository;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Infra.Repository;
using SeiEmDolares.Infra.RepositoryInterface;
using SeiEmDolares.Worker;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IProtocoloRepository, ProtocoloRepository>();
        services.AddTransient<IProtocoloNoSeiEmDolaresRepository,ProtocoloNoSeiEmDolaresRepository>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
