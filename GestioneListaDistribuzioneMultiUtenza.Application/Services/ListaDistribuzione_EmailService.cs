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

        public async Task<ListaDistribuzione_Email> AddDestinatarioToListAsync(int listId, string email)
        {
            int id = await _emailService.OttieniIdEmail(email);
            if(id == 0)
            {
                await _emailService.AggiungiEmailAsync(email);
            }
            var lista = new ListaDistribuzione_Email
            {
                IdLista = listId,
                IdEmailDestinatario = id
            };

            if(await _listaDistribuzioneEmailRepository.CercaListaDistribuzione_Email(listId, id) == null)
            {
                await _listaDistribuzioneEmailRepository.AggiungiAsync(lista);
                await _listaDistribuzioneEmailRepository.SaveAsync();
                return lista;
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
            var idEmail = _emailService.OttieniIdEmail(email);
            return await _listaDistribuzioneEmailRepository.GetFilteredListeByEmail(liste.Item1, idEmail, from, num);

        }

        public async Task<List<EmailDestinatario>> SendEmailToListAsync(int listID)
        {
            return await _emailSenderService.SendEmailAsync("", "", listID);
        }
    }
}
