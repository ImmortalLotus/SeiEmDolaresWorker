using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeiEmDolares.Domain.Entities;

namespace SeiEmDolares.Infra.Mappings
{
    public class MapeamentoProtocoloSeiEmDolares : IEntityTypeConfiguration<ProtocoloSeiEmDolares>
    {
        public void Configure(EntityTypeBuilder<ProtocoloSeiEmDolares> builder)
        {
            builder
                .ToTable("ProtocoloSeiEmDolares");
            builder
                .Property(x => x.ProtocoloId)
                .HasColumnName("id_protocolo");

            builder
               .Property(x => x.FoiImpresso)
               .HasColumnName("foi_impresso");
        }
    }
}
