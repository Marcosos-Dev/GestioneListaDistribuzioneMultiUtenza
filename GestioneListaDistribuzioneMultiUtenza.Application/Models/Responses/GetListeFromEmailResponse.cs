using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class GetListeFromEmailResponse
    {
        public List<ListaDistribuzioneDto> Liste { get; set; } = new List<ListaDistribuzioneDto>();
    }
}
