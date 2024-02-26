using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_EmailService : IListaDistribuzione_EmailService
    {
        private readonly ListaDestinatariRepository _listaDistribuzioneEmailRepository;
        private readonly IEmailService _emailService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;

        public ListaDistribuzione_EmailService(
            ListaDestinatariRepository listaDistribuzioneEmailRepository,
            IEmailService emailService,
            IListaDistribuzioneService listaDistribuzioneService
            )
        {
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
            _emailService = emailService;
            _listaDistribuzioneService = listaDistribuzioneService;
        }

        public async Task AddDestinatarioToListAsync(AddDestinatarioToListRequest item)
        {
            int id = _emailService.OttieniIdEmail(item.email);
            if(id == 0)
            {
                await _emailService.AggiungiEmailAsync(item.email);
            }

            await _listaDistribuzioneEmailRepository.AggiungiAsync(new ListaDistribuzione_Email
            {
                IdLista = item.listId,
                IdEmailDestinatario = id
            });
            await _listaDistribuzioneEmailRepository.SaveAsync();
        }

        public void DeleteDestinatarioFromList(ListaDistribuzione_Email item)
        {
            _listaDistribuzioneEmailRepository.EliminaDestinatarioFromList(item.IdLista,item.IdEmailDestinatario);
        }

        public async Task DeleteDestinatarioFromListAsync(ListaDistribuzione_Email item)
        {
            await _listaDistribuzioneEmailRepository.EliminaDestinatarioFromListAsync(item.IdLista, item.IdEmailDestinatario);
        }

        public async Task<List<ListaDistribuzione>> GetListaDistribuzioneOfUtenteFromEmail(int IdUtente, string email)
        {
            int emailId = _emailService.OttieniIdEmail(email);
            if (emailId != 0)
            {
                var liste = await _listaDistribuzioneService.GetListeOfUtenteAsync(IdUtente);

                return await _listaDistribuzioneEmailRepository.GetFilteredListeByEmail(liste, emailId);
            }
            return new List<ListaDistribuzione>();
        }

        public void SendEmailToList(int listID)
        {
            throw new NotImplementedException();
        }
    }
}
