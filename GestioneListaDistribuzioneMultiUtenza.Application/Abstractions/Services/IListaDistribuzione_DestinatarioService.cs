using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_DestinatarioService
    {
        Task<ListaDistribuzione_Destinatario> AddListaDistribuzione_DestinatarioAsync(int idLista, string email);
        Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, string email);
        Task<(List<ListaDistribuzione>, int)> GetListeUtenteByEmailAsync(int idUtente, string email, int from, int num);
        Task<List<Destinatario>> SendEmailToListaDistribuzioneAsync(string subject, string body, int idLista);
    }
}
