using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Configurations
{
    public class ListaDistribuzioneConfiguration : IEntityTypeConfiguration<ListaDistribuzione>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione> builder)
        {
            builder.ToTable("ListeDistribuzione");
            builder.HasKey(k => k.IdLista);
            builder.HasOne(x => x.UtenteProprietario)
                .WithMany(x => x.ListeDistribuzione)
                .HasForeignKey(x => x.IdProprietario);
        }
    }
}
