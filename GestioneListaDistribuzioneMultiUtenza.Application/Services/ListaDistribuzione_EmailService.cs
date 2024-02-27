using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
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

        public async Task<ListaDistribuzione_Email> AddDestinatarioToListAsync(int listId, string email)
        {
            int id = _emailService.OttieniIdEmail(email);
            if(id == 0)
            {
                await _emailService.AggiungiEmailAsync(email);
            }
            var lista = new ListaDistribuzione_Email
            {
                IdLista = listId,
                IdEmailDestinatario = id
            };

            if(_listaDistribuzioneEmailRepository.CercaListaDistribuzione_Email(listId, id) == null)
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
