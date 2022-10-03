using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Domain.Entities
{
    public class QtdPaginas
    {
        public int Quantidade { get; set; }
        public long IdProtocolo { get; set; }
        public QtdPaginas(int quantidade, long idProtocolo)
        {
            Quantidade = quantidade;
            IdProtocolo = idProtocolo;
        }
    }
}
