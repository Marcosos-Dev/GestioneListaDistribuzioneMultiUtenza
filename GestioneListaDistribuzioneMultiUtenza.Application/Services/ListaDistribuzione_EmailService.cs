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

        public void AddDestinatarioToList(int listID, int emailId)
        {
            _listaDistribuzioneEmailRepository.aggiungiDestinatario(listID, emailId);
        }

        public void DeleteDestinatarioFromList(int listID, int emailId)
        {
            _listaDistribuzioneEmailRepository.eliminaDestinatario(listID, emailId);
        }

        public List<ListaDistribuzione> GetListaDistribuzionesOfEmail(int emailId)
        {
            return _listaDistribuzioneEmailRepository.getListaByEmail(emailId);
        }

        public void SendEmailToList(int listID)
        {
            throw new NotImplementedException();
        }
    }
}
