namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class SendEmailToListRequest
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int listId { get; set; }
    }
}
