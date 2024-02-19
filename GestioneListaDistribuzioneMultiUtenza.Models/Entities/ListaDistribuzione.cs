using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Entities
{
    public class ListaDistribuzione
    {
        public int IdLista {  get; set; }
        public string NomeLista { get; set; }
        public int IdProprietario { get; set; }

        //public ICollection<EmailDestinataria> EmailDestinatarie { get; set; } = null!;
        public Utente UtenteProprietario { get; set; }


    }
}
