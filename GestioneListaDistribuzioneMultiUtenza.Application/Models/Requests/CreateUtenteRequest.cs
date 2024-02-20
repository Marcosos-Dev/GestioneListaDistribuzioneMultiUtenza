using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class CreateUtenteRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Utente toEntity()
        {
            var utente = new Utente();
            utente.Email = Email;
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Password = Password;
            return utente;
        }
    }
}
