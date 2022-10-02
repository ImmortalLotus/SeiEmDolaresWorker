using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using SeiEmDolares.Infra.RepositoryInterface;

namespace SeiEmDolares.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProtocoloNoSeiEmDolaresRepository _protocoloNoSeiRepository;
        private readonly IProtocoloRepository _protocoloRepository;

        public Worker(ILogger<Worker> logger, 
            IProtocoloNoSeiEmDolaresRepository protocoloNoSeiRepository,
            IProtocoloRepository protocoloRepository)
        {
            _logger = logger;
            _protocoloNoSeiRepository = protocoloNoSeiRepository;
            this._protocoloRepository = protocoloRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                /*
                    seu código aqui
                 */
                var listaDeProtocolosDoSeiEmDolares = _protocoloNoSeiRepository.BuscarCemProtocolos();
                using var contexto = new SeiContext("Server=172.16.0.87;Database=sei;User ID=teste_dbinfo;Password=dbinfo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                var listaDeProcotolosDoSei = _protocoloRepository.GetListaDeProcotolosDoSei(listaDeProtocolosDoSeiEmDolares);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}