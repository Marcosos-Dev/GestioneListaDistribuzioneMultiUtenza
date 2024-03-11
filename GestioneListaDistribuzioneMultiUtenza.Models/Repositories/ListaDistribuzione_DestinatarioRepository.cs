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
            var listaDistribuzione_destinatario = await GetListaDistribuzione_DestinatarioAsync(idLista, idDestinatario);

            if (listaDistribuzione_destinatario != null)
            {
                Delete(listaDistribuzione_destinatario);
                await SaveAsync();
            }

            return listaDistribuzione_destinatario;
        }
    }
}
