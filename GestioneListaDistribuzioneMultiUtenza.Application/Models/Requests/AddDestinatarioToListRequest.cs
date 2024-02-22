using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class AddDestinatarioToListRequest
    {
        public int listId { get; set; }
        public string email { get; set; }
    }
}
