using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_Email
    {
        void AddDestinatarioToList(int listID, int emailId);
        void DeleteDestinatarioFromList(int listID, int emailId);
        List<ListaDistribuzione> GetListaDistribuzionesOfEmail(int emailId);
        void SendEmailToList(int listID);
    }
}
