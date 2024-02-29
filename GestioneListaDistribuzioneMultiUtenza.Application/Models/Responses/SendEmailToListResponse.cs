using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class SendEmailToListResponse
    {
        public List<EmailDestinatariDto> EmailDestinatari = new List<EmailDestinatariDto>();
    }
}
