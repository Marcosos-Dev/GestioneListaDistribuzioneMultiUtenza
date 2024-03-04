using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_DestinatarioService : IListaDistribuzione_DestinatarioService
    {
        private readonly ListaDistribuzione_DestinatarioRepository _listaDistribuzione_DestinatarioRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IDestinatarioService _destinatarioService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;

        public ListaDistribuzione_DestinatarioService(
            ListaDistribuzione_DestinatarioRepository listaDistribuzione_DestinatarioRepository,
            IDestinatarioService destinatarioService,
            IListaDistribuzioneService listaDistribuzioneService,
            IEmailSenderService emailSenderService
            )
        {
            _listaDistribuzione_DestinatarioRepository = listaDistribuzione_DestinatarioRepository;
            _destinatarioService = destinatarioService;
            _listaDistribuzioneService = listaDistribuzioneService;
            _emailSenderService = emailSenderService;
        }

        private async Task<ListaDistribuzione_Destinatario> CreateListaDistribuzione_DestinatarioAsync(int idLista, int idEmail)
        {
            var lista = new ListaDistribuzione_Destinatario
            {
                IdLista = idLista,
                IdDestinatario = idEmail
            };
            await _listaDistribuzione_DestinatarioRepository.AddAsync(lista);
            await _listaDistribuzione_DestinatarioRepository.SaveAsync();
            return lista;
        }

        public async Task<ListaDistribuzione_Destinatario> AddListaDistribuzione_DestinatarioAsync(int idLista, string email)
        {
            int idEmail = await _destinatarioService.GetIdDestinatarioAsync(email);
            if(idEmail == 0)
            {
                await _destinatarioService.AddDestinatarioAsync(email);
                idEmail = await _destinatarioService.GetIdDestinatarioAsync(email);
                return await CreateListaDistribuzione_DestinatarioAsync(idLista, idEmail);
            }
            if (await _listaDistribuzione_DestinatarioRepository.GetListaDistribuzione_DestinatarioAsync(idLista, idEmail) == null)
            {
                return await CreateListaDistribuzione_DestinatarioAsync(idLista, idEmail);
            }
            return null;
            
        }

        public async Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, string email)
        {
            var idDestinatario = await _destinatarioService.GetIdDestinatarioAsync(email);
            return await _listaDistribuzione_DestinatarioRepository.DeleteListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);
        }
    }
}
