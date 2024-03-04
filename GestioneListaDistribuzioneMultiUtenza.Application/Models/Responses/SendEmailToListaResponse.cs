using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class SendEmailToListaResponse
    {
        public List<DestinatarioDto> Destinatari = new List<DestinatarioDto>();
    }
}
