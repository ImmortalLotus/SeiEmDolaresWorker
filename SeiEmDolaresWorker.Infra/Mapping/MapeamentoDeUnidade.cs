using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeiEmDolares.Infra.Mapping
{
    public class MapeamentoDeUnidade : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder
                .ToTable("unidade");
            builder
              .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id_unidade");

            builder
                .Property(x => x.Sigla)
                .HasColumnName("sigla");

            builder
                .Property(x => x.SecretariaId)
                .HasColumnName("id_orgao");

            builder
                .Property(x => x.Ativo)
                .HasColumnName("sin_ativo");

            builder
                .HasOne(x => x.Secretaria)
                .WithMany(x => x.ListaDeUnidades)
                .HasForeignKey(x => x.SecretariaId);
        }
    }
}
