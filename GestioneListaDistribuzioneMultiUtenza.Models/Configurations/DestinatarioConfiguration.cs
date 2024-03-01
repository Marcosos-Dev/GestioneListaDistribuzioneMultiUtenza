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
    public class DestinatarioConfiguration : IEntityTypeConfiguration<Destinatario>
    {
        public void Configure(EntityTypeBuilder<Destinatario> builder)
        {
            builder.ToTable("Destinatari");
            builder.HasKey(k => k.IdDestinatario);
        }
    }
}
