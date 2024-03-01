using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class ListaDistribuzione_DestinatarioService : IListaDistribuzione_DestinatarioService
    {
        private readonly ListaDistribuzione_DestinatarioRepository _listaDistribuzione_DestinatarioRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IEmailService _emailService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;

        public ListaDistribuzione_DestinatarioService(
            ListaDistribuzione_DestinatarioRepository listaDistribuzione_DestinatarioRepository,
            IEmailService emailService,
            IListaDistribuzioneService listaDistribuzioneService,
            IEmailSenderService emailSenderService
            )
        {
            _listaDistribuzione_DestinatarioRepository = listaDistribuzione_DestinatarioRepository;
            _emailService = emailService;
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
            int idEmail = await _emailService.GetIdDestinatarioAsync(email);
            if(idEmail == 0)
            {
                await _emailService.AddDestinatarioAsync(email);
                idEmail = await _emailService.GetIdDestinatarioAsync(email);
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
            var idDestinatario = await _emailService.GetIdDestinatarioAsync(email);
            return await _listaDistribuzione_DestinatarioRepository.DeleteListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListeUtenteByEmailAsync(int IdUtente,
            string? email, int from, int num)
        {
            if (string.IsNullOrEmpty(email))
            {
                return await _listaDistribuzioneService.GetListeUtenteAsync(IdUtente, from, num);
            }
            var liste = await _listaDistribuzioneService.GetListeUtenteAsync(IdUtente, null, null);
            var idEmail = await _emailService.GetIdDestinatarioAsync(email);
            return await _listaDistribuzione_DestinatarioRepository.GetListeUtenteByEmailAsync(liste.Item1, idEmail, from, num);

        }

        public async Task<List<Destinatario>> SendEmailToListaDistribuzioneAsync(string subject, string body, int idLista)
        {
            List<int> idsEmail = await _listaDistribuzione_DestinatarioRepository.GetIdsDestinatariAsync(idLista);
            List<Destinatario> emails = await _emailService.GetDestinatariAsync(idsEmail);
            if (emails.Count != 0)
            {
                return await _emailSenderService.SendEmailAsync(subject, body, emails);
            }
            return new List<Destinatario>();
        }
    }
}
