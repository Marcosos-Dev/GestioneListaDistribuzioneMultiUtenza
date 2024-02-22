using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests
{
    public class CreateListaDistribuzioneRequest
    {
        public string NomeLista { get; set; } = string.Empty;

        public ListaDistribuzione ToEntity()
        {
            var listaDistribuzione = new ListaDistribuzione();
            listaDistribuzione.NomeLista = NomeLista;
            return listaDistribuzione;
        }
    }
}
