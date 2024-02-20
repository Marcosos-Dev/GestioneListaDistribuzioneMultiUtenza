using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        Task AddUtenteAsync(Utente utente);
    }
}
