using Microsoft.EntityFrameworkCore;
using Sei.Domain.Entities;
using SeiEmDolares.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.Context
{
    public class SeiContext : DbContext
    {
        private readonly string connectionString;
        public SeiContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Secretaria> Secretaria { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Protocolo> Protocolo { get; set; }
        public DbSet<ConteudoDoDocumento> ConteudoDoDocumento { get; set; }
        public DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDeSecretaria());
            modelBuilder.ApplyConfiguration(new MapeamentoDeProtocolo());
            modelBuilder.ApplyConfiguration(new MapeamentoDeDocumento());
            modelBuilder.ApplyConfiguration(new MapeamentoDeConteudoDoDocumento());
            modelBuilder.ApplyConfiguration(new MapeamentoDeUnidade());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
