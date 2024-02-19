using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class ListaDistribuzioneRepository : GenericRepository<ListaDistribuzione>
    {
        public ListaDistribuzioneRepository(MyDbContext ctx) : base(ctx)
        {

        }
    }
}
