using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_Email
    {
        Task AddDestinatarioToListAsync(ListaDistribuzione_Email item);
        void DeleteDestinatarioFromList(ListaDistribuzione_Email item);
        List<ListaDistribuzione> GetListaDistribuzioneFromEmail(int emailId);
        void SendEmailToList(int listID);
    }
}
