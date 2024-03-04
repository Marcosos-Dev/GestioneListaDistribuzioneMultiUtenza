using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzioneService
    {
        Task AddListaDistribuzioneAsync(ListaDistribuzione lista);
        Task<int> GetProprietarioListaAsync(int idLista);
        Task<(List<ListaDistribuzione>, int)> GetListeUtenteByEmailAsync(int idUtente, string email, int from, int num);
    }
}
