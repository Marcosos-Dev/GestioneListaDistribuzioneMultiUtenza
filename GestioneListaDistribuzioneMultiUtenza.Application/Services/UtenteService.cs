using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository) 
        {
            _utenteRepository = utenteRepository;
        }

        public async Task AddUtenteAsync(Utente utente)
        {
            await _utenteRepository.AggiungiAsync(utente);
            await _utenteRepository.SaveAsync();
        }
    }
}
