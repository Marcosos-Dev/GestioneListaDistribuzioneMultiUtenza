using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class ListaDist_Destinatario
    {
        public int IdListaDestinatari { get; set; }
        public int IdLista {  get; set; }
        public int IdEmailDestinatario { get; set; }

        public ListaDistribuzione ListaDist {  get; set; }
        public EmailDestinatario Destinatario { get; set; }
    }
}
