namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class DeleteListaDistribuzione_DestinatarioRequest
    {
        public int idLista { get; set; }
        public string email { get; set; } = string.Empty;

    }
}
