using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class GetListeFromEmailResponse
    {
        public List<ListaDistribuzioneDto> ListeDistribuzione { get; set; } = new List<ListaDistribuzioneDto>();
        public int NumeroPagine { get; set; }
    }
}
