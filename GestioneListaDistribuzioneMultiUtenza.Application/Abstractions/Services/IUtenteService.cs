using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        Task CreateUtenteAsync(Utente utente);
        Task<Utente> GetUtenteByEmailPasswordAsync(string email, string password);
        Task<Utente> GetAsync(int idUtente);
        Task<Utente> GetUtenteByEmailAsync(string email);
    }
}
