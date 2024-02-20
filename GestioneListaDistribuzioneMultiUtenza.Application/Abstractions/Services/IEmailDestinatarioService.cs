using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IEmailDestinatarioService
    {
        //todo vedere async per la add
        //void addDestinatarioToListAsync(EmailDestinatario email, int idlist);
        void deleteDestinatarioFromList(string email);
        List<ListaDistribuzione> GetListaDistribuzionesOfEmail(string email);
    }
}
