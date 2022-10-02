using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeiEmDolares.Infra.Mapping
{
    public class MapeamentoDeSecretaria : IEntityTypeConfiguration<Secretaria>
    {
        public void Configure(EntityTypeBuilder<Secretaria> builder)
        {
            builder
                .ToTable("orgao");
            builder
              .HasKey(x => x.OrgaoId);

            builder
                .Property(x => x.OrgaoId)
                .HasColumnName("id_orgao");


            builder
                .Property(x => x.Sigla)
                .HasColumnName("sigla");

            builder
                .Property(x => x.Ativo)
                .HasColumnName("sin_ativo");
        }
    }
}
