using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzione
    {
        Task AggiungiListaAsync(ListaDistribuzione lista);
    }
}
