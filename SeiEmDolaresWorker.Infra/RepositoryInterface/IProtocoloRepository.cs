﻿using Sei.Domain.Entities;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sei.Infra.RepositoryInterface
{
    public interface IProtocoloRepository
    {
        Task<ConteudoDoDocumento?> BuscarConteudoDoDocumento(long item, ConteudoDoDocumento? documento);
        public Task<List<long>> GetListaDeProcotolosDoSeiAsync(List<long> listaDeProtocolosDoSeiEmDolares);
    }
}
