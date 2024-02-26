using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_EmailService
    {
        Task AddDestinatarioToListAsync(int listId, string email);
        Task DeleteDestinatarioFromListAsync(int IdLista, int IdEmail);
        Task<List<ListaDistribuzione>> GetListaDistribuzioneOfUtenteFromEmail(int IdUtente, string email);
        void SendEmailToList(int listID);
    }
}
