using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_EmailService
    {
        Task<ListaDistribuzione_Email> AddListaEmailLink(int listId, int emailId);
        Task<ListaDistribuzione_Email> AddDestinatarioToListAsync(int listId, string email);
        Task<ListaDistribuzione_Email> DeleteDestinatarioFromListAsync(int IdLista, int IdEmail);
        Task<(List<ListaDistribuzione>, int)> GetListaDistribuzioneOfUtente(int IdUtente, string email, int from, int num);
        Task<List<EmailDestinatario>> SendEmailToListAsync(string subject, string body, int listID);
    }
}
