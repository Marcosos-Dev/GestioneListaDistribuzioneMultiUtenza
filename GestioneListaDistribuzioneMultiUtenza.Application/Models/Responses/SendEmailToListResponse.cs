using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class SendEmailToListResponse
    {
        public List<DestinatarioDto> DestinatariDto = new List<DestinatarioDto>();
    }
}
