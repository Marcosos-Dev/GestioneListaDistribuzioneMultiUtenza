using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class ListaDistribuzioneRepository : GenericRepository<ListaDistribuzione>
    {
        public ListaDistribuzioneRepository(MyDbContext ctx) : base(ctx)
        {
            
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListeUtenteByEmailAsync(int idUtente, string email, int from, int num)
        {
            var listeUtente = _ctx.ListeDistribuzione
                .Where(l => l.IdProprietario == idUtente)
                .AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                listeUtente = listeUtente.Include(l => l.Destinatari)
                        .ThenInclude(d => d.Destinatario)
                        .Where(l => l.Destinatari.Any(d => d.Destinatario.Email.ToLower().Contains(email.ToLower())));
            }

            var totalNum = listeUtente.Count();

            return (await listeUtente
                .OrderBy(l => l.NomeLista)
                .Skip(from)
                .Take(num)
                .ToListAsync(), totalNum);
        }

        public async Task<ListaDistribuzione> GetListaDistribuzioneByNomeAsync(string nomeLista)
        {
            return await _ctx.ListeDistribuzione
                .Where(l => l.NomeLista.ToLower().Equals(nomeLista.ToLower()))
                .FirstOrDefaultAsync();
        }

    }
}
