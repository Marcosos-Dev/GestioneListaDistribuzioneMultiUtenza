using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailDestinatarioRepository _emailRepository;

        public EmailService(
            EmailDestinatarioRepository emailRepository
            )
        {
            _emailRepository = emailRepository;
        }

        public async Task AggiungiEmailAsync(string email)
        {
            await _emailRepository.AggiungiAsync(new EmailDestinatario
            {
                Email = email
            });
            await _emailRepository.SaveAsync();
        }

        public async Task<int> OttieniIdEmail(string email)
        {
            return await _emailRepository.OttieniIdFromEmail(email);
        }

        public async Task<List<EmailDestinatario>> OttieniEmailFromId(List<int> listId)
        {
            return await _emailRepository.OttieniEmailFromId(listId);
        }
    }
}
