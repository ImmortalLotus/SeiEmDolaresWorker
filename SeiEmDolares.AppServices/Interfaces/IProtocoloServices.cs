using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.AppServices.Interfaces
{
    public interface IProtocoloServices
    {
        Task AtualizarDocumentoEmBranco(long item);
        Task<ConteudoDoDocumento?> BuscarDocumento(long item, ConteudoDoDocumento? documento);
        Task<List<long>> BuscarListaDeProtocolosNoSei(List<long> listaDeProtocolosDoSeiEmDolares);
        Task<List<long>> BuscarListaDeProtocolosNoSeiEmDolares();
        Task ConfirmarImpressao(long item, int QuantidadeDePaginas);
    }
}
