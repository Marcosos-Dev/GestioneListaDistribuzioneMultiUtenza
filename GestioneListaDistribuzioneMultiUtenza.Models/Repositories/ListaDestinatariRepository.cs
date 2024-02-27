using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public async Task<ListaDistribuzione_Email> CercaListaDistribuzione_Email(int listId, int emailId)
        {
            return _ctx.UnioneListe_Destinatari.
                Where(x => x.IdLista == listId && x.IdEmailDestinatario == emailId)
                .FirstOrDefault();
        }

        public async Task<ListaDistribuzione_Email> EliminaDestinatarioFromListAsync(int listId, int emailId)
        {
            var record = _ctx.UnioneListe_Destinatari.
                Where(x => x.IdLista == listId && x.IdEmailDestinatario == emailId)
                .FirstOrDefault();
            if (record != default)
            {
                this.Elimina(record.IdListaDestinatari);
                await this.SaveAsync();
                return record;
            }
            return null;
        }


        public async Task<List<ListaDistribuzione>> GetFilteredListeByEmail(List<ListaDistribuzione> liste, int IdEmail)
        {
            List<int> idsListe = liste.Select(item => item.IdLista).ToList();

            var idListe = await _ctx.UnioneListe_Destinatari
                            .Where(l => idsListe.Contains(l.IdLista) && l.IdEmailDestinatario == IdEmail)
                            .Select(l => l.IdLista)
                            .ToListAsync();

            var filteredLists = liste.Where(item => idListe.Contains(item.IdLista)).ToList();

            return filteredLists;
        }
    }
}
