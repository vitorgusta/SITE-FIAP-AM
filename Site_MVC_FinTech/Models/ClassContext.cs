using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext() : base("Teste") { }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}