using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class ListaDistribuzioneDto
    {
        public ListaDistribuzioneDto() { }
        public ListaDistribuzioneDto(ListaDistribuzione list)
        {
            IdProprietario = list.IdProprietario;
            NomeLista = list.NomeLista;
        }

        public int IdProprietario { get; set; }
        public string NomeLista { get; set; } = string.Empty;
    }
}
