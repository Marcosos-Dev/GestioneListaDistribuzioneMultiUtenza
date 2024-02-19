using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class EmailDestinatario
    {
        public int IdEmailDestinatario { get; set; }
        public string email {  get; set; }

        public ICollection<ListaDist_Destinatario> ListaDiAppartenenze { get; set; } = null!;
    }
}
