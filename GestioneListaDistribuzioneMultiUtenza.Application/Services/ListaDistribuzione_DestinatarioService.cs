using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_DestinatarioService : IListaDistribuzione_DestinatarioService
    {
        private readonly ListaDistribuzione_DestinatarioRepository _listaDistribuzione_DestinatarioRepository;
        private readonly IDestinatarioService _destinatarioService;

        public ListaDistribuzione_DestinatarioService(
            ListaDistribuzione_DestinatarioRepository listaDistribuzione_DestinatarioRepository,
            IDestinatarioService destinatarioService
            )
        {
            _listaDistribuzione_DestinatarioRepository = listaDistribuzione_DestinatarioRepository;
            _destinatarioService = destinatarioService;
        }

        private async Task<ListaDistribuzione_Destinatario> CreateListaDistribuzione_DestinatarioAsync(int idLista, int idDestinatario)
        {
            var lista = new ListaDistribuzione_Destinatario
            {
                IdLista = idLista,
                IdDestinatario = idDestinatario
            };
            await _listaDistribuzione_DestinatarioRepository.AddAsync(lista);
            await _listaDistribuzione_DestinatarioRepository.SaveAsync();
            return lista;
        }

        public async Task<ListaDistribuzione_Destinatario> AddListaDistribuzione_DestinatarioAsync(int idLista, string email)
        {
            int idDestinatario = await _destinatarioService.GetIdDestinatarioAsync(email);
            if(idDestinatario == 0)
            {
                await _destinatarioService.AddDestinatarioAsync(email);
                idDestinatario = await _destinatarioService.GetIdDestinatarioAsync(email);
                return await CreateListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);
            }
            if (await _listaDistribuzione_DestinatarioRepository.GetListaDistribuzione_DestinatarioAsync(idLista, idDestinatario) == null)
            {
                return await CreateListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);
            }
            return default;
            
        }

        public async Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, string email)
        {
            var idDestinatario = await _destinatarioService.GetIdDestinatarioAsync(email);
            return await _listaDistribuzione_DestinatarioRepository.DeleteListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);
        }
    }
}
