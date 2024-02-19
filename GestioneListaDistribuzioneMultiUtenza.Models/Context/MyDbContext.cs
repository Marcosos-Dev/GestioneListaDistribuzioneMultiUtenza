﻿using Microsoft.EntityFrameworkCore;
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

        //public DbSet<Utenti> Utente { get; set; }
        //public DbSet<ListaDistribuziome> ListaDistribuzione { get; set; }
        //public DbSet<EmailDestinataria> EmailDest{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               //.UseLazyLoadingProxies()
               .UseSqlServer("data source=localhost;Initial catalog=paradigmi;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Azienda>(new AziendaConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
