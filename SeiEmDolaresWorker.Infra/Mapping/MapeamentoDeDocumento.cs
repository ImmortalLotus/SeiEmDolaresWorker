using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeiEmDolares.Infra.Mapping
{
    public class MapeamentoDeDocumento : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder
                .ToTable("documento");
            builder
              .HasKey(x => x.DocumentoId);

            builder
                .Property(x => x.DocumentoId)
                .HasColumnName("id_documento");

            builder
             .HasOne(x => x.Protocolo)
             .WithOne(y => y.Documento)
             .HasForeignKey<Documento>(y => y.DocumentoId);
        }
    }
}
