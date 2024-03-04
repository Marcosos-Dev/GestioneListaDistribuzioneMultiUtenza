using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class DestinatarioService : IDestinatarioService
    {
        private readonly DestinatarioRepository _destinatarioRepository;

        public DestinatarioService(DestinatarioRepository destinatarioRepository)
        {
            _destinatarioRepository = destinatarioRepository;
        }

        public async Task AddDestinatarioAsync(string email)
        {
            await _destinatarioRepository.AddAsync(new Destinatario
            {
                Email = email
            });
            await _destinatarioRepository.SaveAsync();
        }

        public async Task<int> GetIdDestinatarioAsync(string email)
        {
            return await _destinatarioRepository.GetIdDestinatarioAsync(email);
        }

        public async Task<List<Destinatario>> GetDestinatariAsync(int idLista)
        {
            return await _destinatarioRepository.GetDestinatariAsync(idLista);
        }
    }
}
