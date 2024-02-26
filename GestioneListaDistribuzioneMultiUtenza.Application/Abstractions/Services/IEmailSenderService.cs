namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(string subject, string body);
    }
}
