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

        public async Task AddListaDistribuzioneAsync(ListaDistribuzione lista)
        {
            await _listaDistribuzioneRepository.AddAsync(lista);
            await _listaDistribuzioneRepository.SaveAsync();
        }

        public async Task<int> GetProprietarioListaAsync(int idLista)
        {
            var lista = await _listaDistribuzioneRepository.GetAsync(idLista);
            if (lista != null)
            {
                return lista.IdProprietario;
            }
            return default;
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListeUtenteAsync(int idUtente, int? from, int? num)
        {
            return await _listaDistribuzioneRepository.GetListeUtenteAsync(idUtente, from, num);
        }
    }
}
