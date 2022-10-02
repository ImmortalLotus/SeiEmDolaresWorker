using SeiEmDolares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.RepositoryInterface
{
    public interface IProtocoloNoSeiEmDolaresRepository
    {
        IQueryable<ProtocoloSeiEmDolares> BuscarCemProtocolos();
    }
}
