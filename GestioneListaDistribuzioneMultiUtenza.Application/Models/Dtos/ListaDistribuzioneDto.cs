using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class ListaDistribuzioneDto
    {
        public ListaDistribuzioneDto() { }
        public ListaDistribuzioneDto(ListaDistribuzione listaDistribuzione)
        {
            IdProprietario = listaDistribuzione.IdProprietario;
            NomeLista = listaDistribuzione.NomeLista;
        }

        public int IdProprietario { get; set; }
        public string NomeLista { get; set; } = string.Empty;
    }
}
