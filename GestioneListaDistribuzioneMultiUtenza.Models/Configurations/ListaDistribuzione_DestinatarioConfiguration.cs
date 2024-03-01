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
    public class ListaDistribuzione_DestinatarioConfiguration : IEntityTypeConfiguration<ListaDistribuzione_Destinatario>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione_Destinatario> builder)
        {
            builder.ToTable("Liste_Destinatari");
            builder.HasKey(k => k.IdListaDestinatari);

            builder.HasOne(x => x.ListaAssociata)
                .WithMany(x => x.Destinatari)
                .HasForeignKey(x => x.IdLista);

            builder.HasOne(x => x.Destinatario)
                .WithMany(x => x.ListeDiAppartenenza)
                .HasForeignKey(x => x.IdDestinatario);
        }
    }
}
