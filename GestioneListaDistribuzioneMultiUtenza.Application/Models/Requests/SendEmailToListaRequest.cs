namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class SendEmailToListaRequest
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int idLista { get; set; }
    }
}
