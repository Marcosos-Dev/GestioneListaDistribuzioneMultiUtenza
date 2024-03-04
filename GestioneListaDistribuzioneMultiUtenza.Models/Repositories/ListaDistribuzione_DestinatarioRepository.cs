using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class ListaDistribuzione_DestinatarioRepository : GenericRepository<ListaDistribuzione_Destinatario>
    {
        public ListaDistribuzione_DestinatarioRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public async Task<ListaDistribuzione_Destinatario> GetListaDistribuzione_DestinatarioAsync(int idLista, int idDestinatario)
        {
            return await _ctx.Liste_Destinatari
                .Where(ld => ld.IdLista == idLista && ld.IdDestinatario == idDestinatario)
                .FirstOrDefaultAsync();
        }

        public async Task<ListaDistribuzione_Destinatario> DeleteListaDistribuzione_DestinatarioAsync(int idLista, int idDestinatario)
        {
            var listaDistribuzione_destinatarioResult = _ctx.Liste_Destinatari
                .Where(ld => ld.IdLista == idLista && ld.IdDestinatario == idDestinatario)
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
