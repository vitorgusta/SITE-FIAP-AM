using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext() : base("Database_Fintech") { }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public DbSet<Pacote> Pacote { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();

            base.OnModelCreating(modelBuilder);
        }

    }
}