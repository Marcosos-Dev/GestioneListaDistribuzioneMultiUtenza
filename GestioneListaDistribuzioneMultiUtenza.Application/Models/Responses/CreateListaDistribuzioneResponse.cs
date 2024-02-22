using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class CreateListaDistribuzioneResponse
    {
        public ListaDistribuzioneDto lista { get; set; } = new ListaDistribuzioneDto();
    }
}
