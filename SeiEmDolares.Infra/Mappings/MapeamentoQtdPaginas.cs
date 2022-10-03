using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeiEmDolares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.Mappings
{
    public class MapeamentoQtdPaginas :IEntityTypeConfiguration<QtdPaginas>
    {
        public void Configure(EntityTypeBuilder<QtdPaginas> builder)
        {
            builder
                .ToTable("QtdPaginasWorker");
            builder
                .Property(x=>x.IdProtocolo)
                .HasColumnName("id_protocolo");
            builder
                .Property(x => x.Quantidade)
                .HasColumnName("quantidade");

        }
    }
}
