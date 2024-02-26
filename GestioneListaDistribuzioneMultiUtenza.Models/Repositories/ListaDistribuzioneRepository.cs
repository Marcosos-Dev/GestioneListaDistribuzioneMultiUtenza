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

        public async Task<List<ListaDistribuzione>> GetListeOfUtenteAsync(int IdUtente)
        {
            return await _ctx.ListeDistribuzione.Where(l => l.IdProprietario.Equals(IdUtente)).ToListAsync();
        }
    }
}
