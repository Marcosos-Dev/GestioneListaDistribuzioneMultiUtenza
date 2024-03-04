using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IDestinatarioService
    {
        public Task AddDestinatarioAsync(string email);

        public Task<int> GetIdDestinatarioAsync(string email);

        public Task<List<Destinatario>> GetDestinatariAsync(int idLista);
    }
}
