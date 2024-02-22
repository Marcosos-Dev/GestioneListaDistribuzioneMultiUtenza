using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        Task AddUtenteAsync(Utente utente);
        Task<Utente> GetUtenteByEmailPasswordAsync(string email, string password);
        Task<Utente> GetUtenteByIdAsync(object id);
    }
}
