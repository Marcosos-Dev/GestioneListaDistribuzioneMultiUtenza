using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzioneService
    {
        Task AggiungiListaAsync(ListaDistribuzione lista);
    }
}
