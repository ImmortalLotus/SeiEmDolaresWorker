using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sei.Domain.Entities;
using Sei.Infra.RepositoryInterface;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sei.Infra.Repository
{
    public class ProtocoloRepository : IProtocoloRepository
    {
        private readonly string _stringConnection;
        private readonly ILogger<ProtocoloRepository> _logger;

        public ProtocoloRepository(IConfiguration configuration, ILogger<ProtocoloRepository> logger)
        {
            _stringConnection = configuration.GetConnectionString("SeiDatabase");
            this._logger = logger;
        }
        public async Task<List<long>> GetListaDeProcotolosDoSeiAsync(List<long> listaDeProtocolosDoSeiEmDolares)
        {
            try
            {
                using (var contexto = new SeiContext(_stringConnection))
                {
                    return await contexto.Protocolo.Where(x => listaDeProtocolosDoSeiEmDolares.Contains(x.ProtocoloId)).Select(x => x.ProtocoloId).ToListAsync();
                }
            }catch(Exception ex)
            {
                await ImprimirErroNoLog(ex);
                return await GetListaDeProcotolosDoSeiAsync(listaDeProtocolosDoSeiEmDolares);
            }
        }
        public async Task<ConteudoDoDocumento?> BuscarConteudoDoDocumento(long item, ConteudoDoDocumento? documento)
        {
            try
            {
                using (var contexto = new SeiContext(_stringConnection))
                {
                    documento = await contexto.ConteudoDoDocumento.Where(x => x.DocumentoId == item).FirstOrDefaultAsync();
                    return documento;
                }
            }
            catch (Exception ex)
            {
                await ImprimirErroNoLog(ex);
                return await BuscarConteudoDoDocumento(item,documento);
            }
        }
        private async Task ImprimirErroNoLog(Exception ex)
        {
            _logger.LogInformation("Erro " + ex.Message + " ao buscar dados no Sei, tentando novamente em 10 minutos...", DateTimeOffset.Now);
            await Task.Delay(600000);
        }
    }
}
