using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeiEmDolares.Infra.Mapping
{ 
    public class MapeamentoDeConteudoDoDocumento : IEntityTypeConfiguration<ConteudoDoDocumento>
    {
        public void Configure(EntityTypeBuilder<ConteudoDoDocumento> builder)
        {
            builder
                .ToTable("documento_conteudo");
            builder
              .HasKey(x => x.DocumentoId);

            builder
                .Property(x => x.DocumentoId)
                .HasColumnName("id_documento");

            builder
               .Property(x => x.Conteudo)
               .HasColumnName("conteudo");



            builder
                .HasOne(x => x.Documento)
                .WithOne(x => x.ConteudoDoDocumento)
                .HasForeignKey<ConteudoDoDocumento>(x => x.DocumentoId);
        }
    }
}
