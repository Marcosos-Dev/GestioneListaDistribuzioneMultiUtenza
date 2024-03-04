namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class ListaDistribuzione_Destinatario
    {
        public int IdListaDestinatari { get; set; }
        public int IdLista {  get; set; }
        public int IdDestinatario { get; set; }

        public ListaDistribuzione ListaAssociata {  get; set; }
        public Destinatario Destinatario { get; set; }
    }
}
