using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class DestinatarioDto
    {
        public DestinatarioDto() { }

        public DestinatarioDto(Destinatario destinatario) 
        {
            Email = destinatario.Email;
        }
        public string Email { get; set; } = string.Empty;
    }
}
