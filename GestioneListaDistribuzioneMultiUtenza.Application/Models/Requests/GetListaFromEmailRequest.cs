namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class GetListaFromEmailRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string email { get; set; }  = string.Empty;
    }
}
