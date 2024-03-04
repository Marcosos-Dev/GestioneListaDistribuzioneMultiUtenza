namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class GetListeUtenteByEmailRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Email { get; set; }  = string.Empty;
    }
}
