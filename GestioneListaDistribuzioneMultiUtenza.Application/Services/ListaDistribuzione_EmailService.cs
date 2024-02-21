using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_EmailService : IListaDistribuzione_Email
    {
        private readonly ListaDestinatariRepository _listaDistribuzioneEmailRepository;

        public ListaDistribuzione_EmailService(
            ListaDestinatariRepository listaDistribuzioneEmailRepository
            )
        {
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
        }

        public async Task AddDestinatarioToListAsync(ListaDistribuzione_Email item)
        {
            await _listaDistribuzioneEmailRepository.AggiungiAsync(item);
            await _listaDistribuzioneEmailRepository.SaveAsync();
        }

        public void DeleteDestinatarioFromList(ListaDistribuzione_Email item)
        {
            _listaDistribuzioneEmailRepository.EliminaDestinatario(item.IdLista,item.IdEmailDestinatario);
        }

        public List<ListaDistribuzione> GetListaDistribuzioneFromEmail(int emailId)
        {
            return _listaDistribuzioneEmailRepository.GetListaByEmail(emailId);
        }

        public void SendEmailToList(int listID)
        {
            throw new NotImplementedException();
        }
    }
}
