﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Configurations
{
    public class ListaDistribuzioneConfiguration //: IEntityTypeConfiguration<Dipendente>
    {
        /*public void Configure(EntityTypeBuilder<Dipendente> builder)
        {
            builder.ToTable("Dipendenti");
            builder.HasKey(k => k.IdDipendente);
            builder.HasOne(x => x.AziendaDoveLavora)
                .WithMany(x => x.Dipendenti)
                .HasForeignKey(x => x.IdAzienda);
        }*/
    }
}
