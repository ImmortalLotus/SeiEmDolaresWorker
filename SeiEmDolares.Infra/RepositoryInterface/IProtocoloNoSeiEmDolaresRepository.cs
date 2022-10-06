using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.RepositoryInterface
{
    public interface IProtocoloNoSeiEmDolaresRepository
    {
        public Task<List<long>> BuscarMilProtocolos();
        public Task<ProtocoloSeiEmDolares?> BuscarProtocoloSeiEmDolares(long item);
        Task SalvarNoSeiEmDolares(int QuantidadeDePaginas, ProtocoloSeiEmDolares? protocolo);
        Task UpdateDocumentoInvalido(long item);
    }
}
