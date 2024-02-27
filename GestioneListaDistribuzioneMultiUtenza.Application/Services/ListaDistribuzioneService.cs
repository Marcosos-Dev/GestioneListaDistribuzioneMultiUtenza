using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzioneService : IListaDistribuzioneService
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

        public async Task<int> OttieniProprietarioListaAsync(int IdLista)
        {
            var lista = await _listaDistribuzioneRepository.OttieniAsync(IdLista);
            if (lista != null)
            {
                return lista.IdProprietario;
            }
            return default;
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListeOfUtenteAsync(int IdUtente, int? from, int? num)
        {
            return await _listaDistribuzioneRepository.GetListeOfUtenteAsync(IdUtente, from, num);
        }
    }
}
