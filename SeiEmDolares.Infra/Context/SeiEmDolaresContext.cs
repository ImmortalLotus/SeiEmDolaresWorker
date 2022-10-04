using Microsoft.EntityFrameworkCore;
using SeiEmDolares.Domain.Entities;
using SeiEmDolares.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiEmDolares.Infra.Context
{
    public class SeiEmDolaresContext : DbContext
    {
        private readonly string connectionString;
        public SeiEmDolaresContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoProtocoloSeiEmDolares());
        }
        public DbSet<ProtocoloSeiEmDolares> ProtocoloEmDolares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
