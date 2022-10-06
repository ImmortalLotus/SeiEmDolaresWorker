using Sei.Infra.Repository;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.AppServices.Interfaces;
using SeiEmDolares.AppServices.Services;
using SeiEmDolares.Infra.Repository;
using SeiEmDolares.Infra.RepositoryInterface;
using SeiEmDolares.Worker;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IProtocoloRepository, ProtocoloRepository>();
        services.AddTransient<IProtocoloNoSeiEmDolaresRepository,ProtocoloNoSeiEmDolaresRepository>();
        services.AddTransient<IProtocoloServices, ProtocoloServices>();
        services.AddTransient<IImpressaoServices, ImpressaoServices>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
