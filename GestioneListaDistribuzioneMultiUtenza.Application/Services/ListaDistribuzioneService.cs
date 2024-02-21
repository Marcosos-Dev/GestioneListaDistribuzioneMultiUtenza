using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzioneService : IListaDistribuzione
    {
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;

        public ListaDistribuzioneService(
            ListaDistribuzioneRepository listaDistribuzioneRepository
            )
        {
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
        }

        public async Task AggiungiListaAsync(ListaDistribuzione lista)
        {
            await _listaDistribuzioneRepository.AggiungiAsync(lista);
            await _listaDistribuzioneRepository.SaveAsync();
        }
    }
}
