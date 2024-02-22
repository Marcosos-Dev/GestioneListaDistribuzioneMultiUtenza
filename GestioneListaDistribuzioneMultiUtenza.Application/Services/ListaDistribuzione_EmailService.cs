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

        public ListaDistribuzione_EmailService(
            ListaDestinatariRepository listaDistribuzioneEmailRepository,
            IEmailService emailService
            )
        {
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
            _emailService = emailService;
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

        public List<ListaDistribuzione> GetListaDistribuzioneFromEmail(GetListaFromEmailRequest request)
        {
            int emailId = _emailService.OttieniIdEmail(request.email);
            if (emailId != 0)
            {
                return _listaDistribuzioneEmailRepository.GetListaByEmail(emailId);
            }
            return new List<ListaDistribuzione>();
        }

        public void SendEmailToList(int listID)
        {
            throw new NotImplementedException();
        }
    }
}
