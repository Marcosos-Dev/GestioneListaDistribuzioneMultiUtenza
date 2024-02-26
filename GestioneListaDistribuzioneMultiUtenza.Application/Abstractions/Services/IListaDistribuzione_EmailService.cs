using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_EmailService
    {
        Task AddDestinatarioToListAsync(AddDestinatarioToListRequest item);
        void DeleteDestinatarioFromList(ListaDistribuzione_Email item);
        Task DeleteDestinatarioFromListAsync(ListaDistribuzione_Email item);
        Task<List<ListaDistribuzione>> GetListaDistribuzioneOfUtenteFromEmail(int IdUtente, string email);
        void SendEmailToList(int listID);
    }
}
