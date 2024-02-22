    using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class DeleteListaDistribuzione_EmailRequest
    {
        public int listId { get; set; }
        public int emailId { get; set; }

        public ListaDistribuzione_Email ToEntity()
        {
            var listaDistribuzione_Email = new ListaDistribuzione_Email();
            listaDistribuzione_Email.IdLista = listId;
            listaDistribuzione_Email.IdEmailDestinatario = emailId;
            return listaDistribuzione_Email;
        }
    }
}
