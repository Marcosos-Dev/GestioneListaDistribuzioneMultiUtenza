using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailService
    {
        public Task AggiungiEmailAsync(string email);

        public int OttieniIdEmail(string email);
    }
}
