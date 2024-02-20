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
    public class ListeDestinatariConfiguration : IEntityTypeConfiguration<ListaDistribuzione_Email>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione_Email> builder)
        {
            builder.ToTable("Liste_Destinatari");
            builder.HasKey(k => k.IdListaDestinatari);

            builder.HasOne(x => x.ListaAssociata)
                .WithMany(x => x.EmailDestinatarie)
                .HasForeignKey(x => x.IdLista);

            builder.HasOne(x => x.Destinatario)
                .WithMany(x => x.ListeDiAppartenenze)
                .HasForeignKey(x => x.IdEmailDestinatario);
        }
    }
}
