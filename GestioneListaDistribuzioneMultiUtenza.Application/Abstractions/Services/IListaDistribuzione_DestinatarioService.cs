using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione_DestinatarioService
    {
        Task<ListaDistribuzione_Destinatario> AddListaDistribuzione_DestinatarioAsync(int idLista, string email);
        Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, string email);
    }
}
