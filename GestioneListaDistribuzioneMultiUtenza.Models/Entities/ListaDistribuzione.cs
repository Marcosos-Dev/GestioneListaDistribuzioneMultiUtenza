namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class ListaDistribuzione
    {
        public int IdLista {  get; set; }
        public int IdProprietario { get; set; }
        public string NomeLista { get; set; }

        public ICollection<ListaDistribuzione_Destinatario> Destinatari { get; set; } = null!;
        public Utente UtenteProprietario { get; set; }


    }
}
