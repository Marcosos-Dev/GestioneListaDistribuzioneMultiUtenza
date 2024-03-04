using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class ListaDistribuzioneRepository : GenericRepository<ListaDistribuzione>
    {
        public ListaDistribuzioneRepository(MyDbContext ctx) : base(ctx)
        {
            
        }

        public async Task<(List<ListaDistribuzione>, int)> GetListeUtenteByEmailAsync(int idUtente, string email, int from, int num)
        {
            var query = _ctx.ListeDistribuzione.
                Where(l => l.IdProprietario == idUtente).
                    Include(l => l.Destinatari).
                        ThenInclude(d => d.Destinatario).AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(l => l.Destinatari.Any(d => d.Destinatario.Email.ToLower().Contains(email.ToLower())));
            }

            var totalNum = query.Count();

            return (await query
                .OrderBy(l => l.NomeLista)
                .Skip(from)
                .Take(num)
                .ToListAsync(), totalNum);
        }

    }
}
