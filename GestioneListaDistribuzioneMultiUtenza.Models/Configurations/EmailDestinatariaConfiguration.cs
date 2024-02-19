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
    public class EmailDestinatariaConfiguration : IEntityTypeConfiguration<EmailDestinatario>
    {
        public void Configure(EntityTypeBuilder<EmailDestinatario> builder)
        {
            builder.ToTable("Dipendenti");
            builder.HasKey(k => k.IdDestinatario);
            builder.HasOne(x => x.ListaDiAppartenenza)
                .WithMany(x => x.EmailDestinatarie)
                .HasForeignKey(x => x.ListaDistribuzioneId);
        }
    }
}
