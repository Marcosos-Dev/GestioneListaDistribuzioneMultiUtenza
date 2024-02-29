using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class EmailDestinatariDto
    {
        public EmailDestinatariDto() { }

        public EmailDestinatariDto(EmailDestinatario emailDestinatario) 
        {
            Email = emailDestinatario.Email;
        }
        public string Email { get; set; } = string.Empty;
    }
}
