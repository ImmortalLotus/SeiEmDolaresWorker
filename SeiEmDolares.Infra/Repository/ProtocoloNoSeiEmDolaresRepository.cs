using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using SeiEmDolares.Infra.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.Repository
{
    public class ProtocoloNoSeiEmDolaresRepository : IProtocoloNoSeiEmDolaresRepository
    {
        private readonly string _stringConnection;
        private readonly ILogger<ProtocoloNoSeiEmDolaresRepository> _logger;

        public ProtocoloNoSeiEmDolaresRepository(IConfiguration configuration, ILogger<ProtocoloNoSeiEmDolaresRepository> logger)
        {
            _stringConnection = configuration.GetConnectionString("SeiEmDolaresDatabase");
            this._logger = logger;
        }
        public async Task<List<long>> BuscarMilProtocolos()
        {
            try
            {
                using (var context = new SeiEmDolaresContext(_stringConnection))
                {
                    return await context.ProtocoloEmDolares.Where(x => x.FoiImpresso == 0).OrderBy(p => p.ProtocoloId).Select(x => x.ProtocoloId).Take(1000).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                await ImprimirErroNoLog(ex);
                return await BuscarMilProtocolos();
            }
        }
        public async Task UpdateDocumentoInvalido(long item)
        {
            try
            {
                _logger.LogInformation("Documento nulo encontrado, realizando o tratamento", DateTimeOffset.Now);
                using (var context = new SeiEmDolaresContext(_stringConnection))
                {
                    var protocolo = await context.ProtocoloEmDolares.Where(x => x.ProtocoloId == item).FirstAsync();
                    await SalvarNoSeiEmDolares(0, protocolo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Erro ao corrigir documento em branco, realizando o tratamento", DateTimeOffset.Now);
                await ImprimirErroNoLog(ex);
                await UpdateDocumentoInvalido(item);
            }
        }

        private async Task ImprimirErroNoLog(Exception ex)
        {
            _logger.LogInformation("Erro " + ex.Message + " ao buscar dados no SeiEmDolares, tentando novamente em 10 minutos...", DateTimeOffset.Now);
            await Task.Delay(600000);
        }

        public async Task SalvarNoSeiEmDolares(int QuantidadeDePaginas, ProtocoloSeiEmDolares? protocolo)
        {
            try
            {
                using (var contexto = new SeiEmDolaresContext(_stringConnection))
                {
                    protocolo.FoiImpresso = 1;
                    protocolo.Quantidade = QuantidadeDePaginas;
                    contexto.Update(protocolo);
                    await contexto.SaveChangesAsync();
                    contexto.ChangeTracker.Clear();
                }
            }
            catch (Exception ex)
            {
                await ImprimirErroNoLog(ex);
                await SalvarNoSeiEmDolares(QuantidadeDePaginas, protocolo);
            }
        }
        public async Task<ProtocoloSeiEmDolares?> BuscarProtocoloSeiEmDolares(long item)
        {
            try
            {
                using (var contexto = new SeiEmDolaresContext(_stringConnection))
                {
                    return contexto.ProtocoloEmDolares.Where(x => x.ProtocoloId == item).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                await ImprimirErroNoLog(ex);
                return await BuscarProtocoloSeiEmDolares(item);
            }
        }
    }
}
