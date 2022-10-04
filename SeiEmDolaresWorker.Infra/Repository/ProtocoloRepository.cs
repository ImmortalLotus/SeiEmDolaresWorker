using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public ProtocoloRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("SeiDatabase");
        }
        public async Task<List<long>> GetListaDeProcotolosDoSeiAsync(List<long> listaDeProtocolosDoSeiEmDolares)
        {
            using (var contexto = new SeiContext(_stringConnection))
            {
                return await contexto.Protocolo.Where(x => listaDeProtocolosDoSeiEmDolares.Contains(x.ProtocoloId)).Select(x => x.ProtocoloId).ToListAsync();
            }
        }
    }
}
