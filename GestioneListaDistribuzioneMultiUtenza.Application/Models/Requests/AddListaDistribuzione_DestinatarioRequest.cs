using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class AddListaDistribuzione_DestinatarioRequest
    {
        public int idLista { get; set; }
        public string email { get; set; } = string.Empty;


    }
}
