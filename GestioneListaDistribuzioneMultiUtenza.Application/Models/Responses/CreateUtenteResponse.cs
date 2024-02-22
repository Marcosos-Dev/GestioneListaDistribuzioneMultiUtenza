using GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses
{
    public class CreateUtenteResponse
    {
        public UtenteDto Utente { get; set; } = new UtenteDto();
    }
}
