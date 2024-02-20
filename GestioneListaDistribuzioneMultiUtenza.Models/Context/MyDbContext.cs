using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<ListaDistribuzione> ListeDistribuzione { get; set; }
        public DbSet<ListaDistribuzione_Email> UnioneListe_Destinatari { get; set; }
        public DbSet<EmailDestinatario> EmailDestinatarie{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("data source=localhost;Initial catalog=DistribuzioneMultiUtenza;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True;Trusted_Connection=true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
