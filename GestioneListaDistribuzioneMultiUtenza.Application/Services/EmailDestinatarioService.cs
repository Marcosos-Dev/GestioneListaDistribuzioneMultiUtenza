using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class EmailDestinatarioService : IEmailDestinatarioService
    {
        private readonly EmailDestinatarioRepository _emailRepository;

        public EmailDestinatarioService(
            EmailDestinatarioRepository emailRepository
            )
        {
            _emailRepository = emailRepository;
        }

        /*public void addDestinatarioToListAsync(EmailDestinatario email, int list)
        {
            _emailRepository.addEmailWithList(email, list);
            _emailRepository.Save();
        }*/

        public void deleteDestinatarioFromList(string email)
        {
            _emailRepository.Elimina(email);
            _emailRepository.Save();
        }

        //TODO INSERIRE PAGINAZIONE NEI METODI
        public List<ListaDistribuzione> GetListaDistribuzionesOfEmail(string email)
        {
            return _emailRepository.getListaByEmail(email);
        }
    }
}
