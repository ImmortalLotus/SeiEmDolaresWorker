using Microsoft.Extensions.Logging;
using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.AppServices.Interfaces;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.AppServices.Services
{
    public class ProtocoloServices : IProtocoloServices
    {
        private readonly IProtocoloRepository _protocoloRepository;
        private readonly IProtocoloNoSeiEmDolaresRepository _protocoloNoSeiRepository;
        private readonly ILogger<ProtocoloServices> _logger;

        public ProtocoloServices(IProtocoloRepository protocoloRepository,IProtocoloNoSeiEmDolaresRepository protocoloNoSeiRepository, ILogger<ProtocoloServices> logger)
        {
            this._protocoloRepository = protocoloRepository;
            this._protocoloNoSeiRepository = protocoloNoSeiRepository;
            this._logger = logger;
        }
        public async Task<List<long>> BuscarListaDeProtocolosNoSeiEmDolares()
        {
            var listaDeProtocolosDoSeiEmDolares = await _protocoloNoSeiRepository.BuscarMilProtocolos();
            if (listaDeProtocolosDoSeiEmDolares is null || !listaDeProtocolosDoSeiEmDolares.Any())
            {
                _logger.LogInformation("Não foram encontrados registros não impressos, esperando trinta minutos...", DateTimeOffset.Now);
                await Task.Delay(1800000);
                return await BuscarListaDeProtocolosNoSeiEmDolares();
            }

            return listaDeProtocolosDoSeiEmDolares;
        }
        public async Task<ConteudoDoDocumento?> BuscarDocumento(long item, ConteudoDoDocumento? documento)
        {
            documento = await _protocoloRepository.BuscarConteudoDoDocumento(item, documento);
            return documento;
        }
        public async Task AtualizarDocumentoEmBranco(long item)
        {
            await _protocoloNoSeiRepository.UpdateDocumentoInvalido(item);
        }
        public async Task ConfirmarImpressao(long item, int QuantidadeDePaginas)
        {
            ProtocoloSeiEmDolares? protocolo = await _protocoloNoSeiRepository.BuscarProtocoloSeiEmDolares(item);
            if (protocolo is not null)
            {
                await _protocoloNoSeiRepository.SalvarNoSeiEmDolares(QuantidadeDePaginas, protocolo);
            }
        }

        public async Task<List<long>> BuscarListaDeProtocolosNoSei(List<long> listaDeProtocolosDoSeiEmDolares)
        {
            var listaDeProtocolosDoSei = await _protocoloRepository.GetListaDeProcotolosDoSeiAsync(listaDeProtocolosDoSeiEmDolares);
            if (listaDeProtocolosDoSei is null || !listaDeProtocolosDoSei.Any())
            {
                _logger.LogInformation("Não foram encontrados registros no Sei, esperando trinta minutos...", DateTimeOffset.Now);
                await Task.Delay(1800000);
                return await BuscarListaDeProtocolosNoSei(listaDeProtocolosDoSeiEmDolares);
            }
            return listaDeProtocolosDoSeiEmDolares;
        }
    }
}
