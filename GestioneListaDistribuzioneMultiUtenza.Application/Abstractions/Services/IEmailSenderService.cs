using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailSenderService
    {
        public Task<List<Destinatario>> SendEmailAsync(string subject, string body, List<Destinatario> destinatari);
    }
}
