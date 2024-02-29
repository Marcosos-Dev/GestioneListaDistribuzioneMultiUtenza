using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_EmailService : IListaDistribuzione_EmailService
    {
        private readonly ListaDestinatariRepository _listaDistribuzioneEmailRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IEmailService _emailService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;

        public ListaDistribuzione_EmailService(
            ListaDestinatariRepository listaDistribuzioneEmailRepository,
            IEmailService emailService,
            IListaDistribuzioneService listaDistribuzioneService,
            IEmailSenderService emailSenderService
            )
        {
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
            _emailService = emailService;
            _listaDistribuzioneService = listaDistribuzioneService;
            _emailSenderService = emailSenderService;
        }

        public async Task<ListaDistribuzione_Email> AddListaEmailLink(int listId, int emailId)
        {
            var lista = new ListaDistribuzione_Email
            {
                IdLista = listId,
                IdEmailDestinatario = emailId
            };
            await _listaDistribuzioneEmailRepository.AggiungiAsync(lista);
            await _listaDistribuzioneEmailRepository.SaveAsync();
            return lista;
        }

        public async Task<ListaDistribuzione_Email> AddDestinatarioToListAsync(int listId, string email)
        {
            int emailId = await _emailService.OttieniIdEmail(email);
            if(emailId == 0)
            {
                await _emailService.AggiungiEmailAsync(email);
                emailId = await _emailService.OttieniIdEmail(email);
                return await AddListaEmailLink(listId, emailId);
            }
            if (await _listaDistribuzioneEmailRepository.CercaListaDistribuzione_Email(listId, emailId) == null)
            {
                return await AddListaEmailLink(listId, emailId);
            }
            return null;
            
        }

        public async Task<ListaDistribuzione_Email> DeleteDestinatarioFromListAsync(int IdLista, int IdEmail)
        {
            return await _listaDistribuzioneEmailRepository.EliminaDestinatarioFromListAsync(IdLista, IdEmail);
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListaDistribuzioneOfUtente(int IdUtente,
            string? email, int from, int num)
        {
            if (string.IsNullOrEmpty(email))
            {
                return await _listaDistribuzioneService.GetListeOfUtenteAsync(IdUtente, from, num);
            }
            var liste = await _listaDistribuzioneService.GetListeOfUtenteAsync(IdUtente, null, null);
            var idEmail = await _emailService.OttieniIdEmail(email);
            return await _listaDistribuzioneEmailRepository.GetFilteredListeByEmail(liste.Item1, idEmail, from, num);

        }

        public async Task<List<EmailDestinatario>> SendEmailToListAsync(int listID)
        {
            List<int> listaEmailUtente = await _listaDistribuzioneEmailRepository.GetEmailIdFromListId(listID);
            List<EmailDestinatario> emails = await _emailService.OttieniEmailFromId(listaEmailUtente);
            if (emails.Count != 0)
            {
                return await _emailSenderService.SendEmailAsync("", "", emails);
            }
            return new List<EmailDestinatario>();
        }
    }
}
