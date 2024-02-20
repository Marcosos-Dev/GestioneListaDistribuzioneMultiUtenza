﻿using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using System;
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
    }
}