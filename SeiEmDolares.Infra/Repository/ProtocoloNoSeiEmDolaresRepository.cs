using Microsoft.Extensions.Configuration;
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
        public ProtocoloNoSeiEmDolaresRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("SeiDatabase");
        }
        public IQueryable<ProtocoloSeiEmDolares> BuscarCemProtocolos()
        {
            using var context= new SeiEmDolaresContext(_stringConnection);
            return context.ProtocoloEmDolares.Where(x=>x.FoiImpresso==0).OrderBy(p =>p.ProtocoloId).Take(100);
        }
    }
}
