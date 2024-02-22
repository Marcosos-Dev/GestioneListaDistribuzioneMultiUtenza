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

        public async Task<Utente> GetUtenteByEmailPasswordAsync(string email, string password)
        {
            return await _utenteRepository.GetUtenteByEmailPasswordAsync(email,password);
        }

        public async Task<Utente> GetUtenteByIdAsync(object id)
        {
            return await _utenteRepository.OttieniAsync(id);
        }
    }
}
