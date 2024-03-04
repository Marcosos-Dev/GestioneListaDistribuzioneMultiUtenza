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
    public class ListaDistribuzione_DestinatarioRepository : GenericRepository<ListaDistribuzione_Destinatario>
    {
        public ListaDistribuzione_DestinatarioRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public async Task<List<int>> GetIdsDestinatariAsync(int idLista)
        {
            return await _ctx.Liste_Destinatari.
                Where(x => x.IdLista == idLista).
                Select(x => x.IdDestinatario).
                ToListAsync();
        }

        public async Task<ListaDistribuzione_Destinatario> GetListaDistribuzione_DestinatarioAsync(int idLista, int idEmail)
        {
            return await _ctx.Liste_Destinatari.
                Where(x => x.IdLista == idLista && x.IdDestinatario == idEmail)
                .FirstOrDefaultAsync();
        }

        public async Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, int idDestinatario)
        {
            var listaDistribuzione_destinatarioResult = _ctx.Liste_Destinatari.
                Where(x => x.IdLista == idLista && x.IdDestinatario == idDestinatario)
                .FirstOrDefault();
            if (listaDistribuzione_destinatarioResult != null)
            {
                await DeleteAsync(listaDistribuzione_destinatarioResult.IdListaDestinatari);
                await SaveAsync();
            }
            return listaDistribuzione_destinatarioResult;
        }
    }
}
