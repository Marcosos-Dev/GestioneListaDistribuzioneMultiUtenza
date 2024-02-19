using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class Utente
    {
        public int IdUtente { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }

        public ICollection<ListaDistribuzione> ListeDistribuzione { get; set; } = null!;
    }
}
