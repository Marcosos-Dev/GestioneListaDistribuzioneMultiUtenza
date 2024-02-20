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
        public string Email {  get; set; }

        public ICollection<ListaDistribuzione_Email> ListeDiAppartenenze { get; set; } = null!;
    }
}
