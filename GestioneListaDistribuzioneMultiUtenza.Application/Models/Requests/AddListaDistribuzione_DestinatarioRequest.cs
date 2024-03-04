namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class AddListaDistribuzione_DestinatarioRequest
    {
        public int IdLista { get; set; }
        public string Email { get; set; } = string.Empty;


    }
}
