using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class CreateEmailDestinatarioRequest
    {
        public string email { get; set; } = string.Empty;

        public EmailDestinatario ToEntity()
        {
            var emailDest = new EmailDestinatario();
            emailDest.Email = email;
            return emailDest;
        }
    }
}
