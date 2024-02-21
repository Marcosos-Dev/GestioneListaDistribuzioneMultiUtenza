using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class CreateListaDistribuzioneRequest
    {
        public int IdProprietario { get; set; }
        public string NomeLista { get; set; } = string.Empty;

        public ListaDistribuzione ToEntity()
        {
            var listaDistribuzione = new ListaDistribuzione();
            listaDistribuzione.IdProprietario = IdProprietario;
            listaDistribuzione.NomeLista = NomeLista;
            return listaDistribuzione;
        }
    }
}
