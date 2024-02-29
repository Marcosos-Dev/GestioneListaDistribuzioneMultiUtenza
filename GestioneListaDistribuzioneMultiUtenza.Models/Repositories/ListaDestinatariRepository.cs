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

        public async Task<List<int>> GetEmailIdFromListId(int listId)
        {
            return await _ctx.UnioneListe_Destinatari.
                Where(x => x.IdLista == listId).
                Select(x => x.IdEmailDestinatario).
                ToListAsync();
        }

        public async Task<ListaDistribuzione_Email> CercaListaDistribuzione_Email(int listId, int emailId)
        {
            return await _ctx.UnioneListe_Destinatari.
                Where(x => x.IdLista == listId && x.IdEmailDestinatario == emailId)
                .FirstOrDefaultAsync();
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


        public async Task<(List<ListaDistribuzione>, int)> GetFilteredListeByEmail(List<ListaDistribuzione> listeUtente, int IdEmail,
            int from, int num)
        {
            List<int> idsListe = listeUtente.Select(l => l.IdLista).ToList();

            var idListe = await _ctx.UnioneListe_Destinatari
                            .Where(l => idsListe.Contains(l.IdLista) && l.IdEmailDestinatario == IdEmail)
                            .Select(l => l.IdLista)
                            .ToListAsync();

            var filteredLists = listeUtente.Where(l => idListe.Contains(l.IdLista)).ToList();
            int totalNum = filteredLists.Count();
            var filteredLists1 = filteredLists.OrderBy(l => l.NomeLista).Skip((int)from).Take((int)num).ToList();
            return (filteredLists1, totalNum);
        }
    }
}
