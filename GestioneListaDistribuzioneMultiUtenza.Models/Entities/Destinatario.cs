using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class Destinatario
    {
        public int IdDestinatario { get; set; }
        public string Email {  get; set; }

        public ICollection<ListaDistribuzione_Destinatario> ListeDiAppartenenza { get; set; } = null!;
    }
}
