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

        public async Task<(List<ListaDistribuzione>, int)> GetListeUtenteAsync(int idUtente, int? from, int? num)
        {
            var liste = _ctx.ListeDistribuzione.Where(l => l.IdProprietario.Equals(idUtente)).AsQueryable();
            int totalNum = liste.Count();
            if (from != null && num != null)
            {
                var PagedListe = await liste.OrderBy(l => l.NomeLista).Skip((int)from).Take((int)num).ToListAsync();
                return (PagedListe, totalNum);
            }
            return (await liste.ToListAsync(), totalNum);
        }
    }
}
