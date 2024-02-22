using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_EmailService
    {
        Task AddDestinatarioToListAsync(AddDestinatarioToListRequest item);
        void DeleteDestinatarioFromList(ListaDistribuzione_Email item);
        List<ListaDistribuzione> GetListaDistribuzioneFromEmail(GetListaFromEmailRequest email);
        void SendEmailToList(int listID);
    }
}
