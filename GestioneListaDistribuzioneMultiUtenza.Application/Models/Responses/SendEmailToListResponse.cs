using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class SendEmailToListResponse
    {
        public List<EmailDestinatariDto> EmailDestinatariDto = new List<EmailDestinatariDto>();
    }
}
