using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Configurations
{
    public class ListaDistribuzioneConfiguration : IEntityTypeConfiguration<ListaDistribuzione>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione> builder)
        {
            builder.ToTable("ListeDistribuzione");
            builder.HasKey(k => k.IdLista);
            builder.HasOne(x => x.IdLista)
                .WithMany(x => x.)
                .HasForeignKey(x => x);
        }
    }
}
