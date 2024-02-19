using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class EmailDestinataria
    {
        public int IdDestinatario { get; set; }
        public int ListaDistribuzioneId {  get; set; }
        public string Email {  get; set; }

        public ListaDistribuzione ListaDiAppartenenza { get; set; }
    }
}
