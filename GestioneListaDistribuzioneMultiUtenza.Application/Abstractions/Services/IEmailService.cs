using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public Task AddDestinatarioAsync(string email);

        public Task<int> GetIdDestinatarioAsync(string email);

        public Task<List<Destinatario>> GetDestinatariAsync(List<int> idLista);
    }
}
