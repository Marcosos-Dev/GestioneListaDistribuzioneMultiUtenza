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

        public async Task CreateUtenteAsync(Utente utente)
        {
            await _utenteRepository.AddAsync(utente);
            await _utenteRepository.SaveAsync();
        }

        public async Task<Utente> GetUtenteByEmailPasswordAsync(string email, string password)
        {
            return await _utenteRepository.GetUtenteByEmailPasswordAsync(email,password);
        }

        public async Task<Utente> GetAsync(int idUtente)
        {
            return await _utenteRepository.GetAsync(idUtente);
        }

        public async Task<Utente> GetUtenteByEmailAsync(string email)
        {
            return await _utenteRepository.GetUtenteByEmailAsync(email);
        }
    }
}
