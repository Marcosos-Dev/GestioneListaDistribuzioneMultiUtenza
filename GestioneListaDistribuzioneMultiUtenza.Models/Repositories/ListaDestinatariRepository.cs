using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class ListaDestinatariRepository : GenericRepository<ListaDistribuzione_Email>
    {
        public ListaDestinatariRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public void aggiungiDestinatario(int listId, int emailId)
        {
            ListaDistribuzione_Email dest = new ListaDistribuzione_Email();
            dest.IdEmailDestinatario = emailId;
            dest.IdLista = listId;
            this.Aggiungi(dest);
            this.Save();
        }

        public void eliminaDestinatario(int listId, int emailId)
        {
            var record = _ctx.UnioneListe_Destinatari.
                Where(x => x.IdLista == listId && x.IdEmailDestinatario == emailId)
                .First();
            this.Elimina(record.IdListaDestinatari);
            this.Save();
        }

        /*Dato un destinatario ottenere tutte le liste di distribuzione a lui associate
        La ricerca dovrà paginare i risultanti, in base ad un parametro passato nella chiamata*/
        public List<ListaDistribuzione> getListaByEmail(int emailId)
        {
            //TODO PAGINARE
            //Prendo gli id delle liste collegate alla mail
            var idListe = _ctx.UnioneListe_Destinatari.
                Where(l => l.IdEmailDestinatario == emailId).
                Select(l => l.IdLista).
                ToList();
            //ritorno tutte le liste desiderate
            return _ctx.ListeDistribuzione.
                Where(i => idListe.Contains(i.IdLista))
                .ToList(); ;
        }
    }
}
