using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailSenderService
    {
        public Task<List<EmailDestinatario>> SendEmailAsync(string subject, string body, List<EmailDestinatario> email);
    }
}
