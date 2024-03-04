using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class ListaDistribuzioneDto
    {
        public ListaDistribuzioneDto() { }
        public ListaDistribuzioneDto(ListaDistribuzione listaDistribuzione)
        {
            NomeLista = listaDistribuzione.NomeLista;
        }
        public string NomeLista { get; set; } = string.Empty;
    }
}
