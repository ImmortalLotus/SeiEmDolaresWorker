using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeiEmDolares.Infra.Mapping
{
    public class MapeamentoDeProtocolo : IEntityTypeConfiguration<Protocolo>
    {
        public void Configure(EntityTypeBuilder<Protocolo> builder)
        {
            builder
                .ToTable("protocolo");
            builder
              .HasKey(x => x.ProtocoloId);

            builder
                .Property(x => x.ProtocoloId)
                .HasColumnName("id_protocolo");

            builder
                .Property(x => x.DataGeracao)
                .HasColumnName("dta_geracao");

            builder
                .Property(x => x.ProtocoloFormatado)
                .HasColumnName("protocolo_formatado");

            builder
               .Property(x => x.UnidadeId)
               .HasColumnName("id_unidade_geradora");

            builder
                .HasOne(x => x.Unidade)
                .WithMany(x => x.ListaDeProtocolos)
                .HasForeignKey(x => x.UnidadeId);
        }
    }
}
