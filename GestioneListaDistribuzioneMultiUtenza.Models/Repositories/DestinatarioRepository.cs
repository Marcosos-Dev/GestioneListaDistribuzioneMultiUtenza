﻿using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class DestinatarioRepository : GenericRepository<Destinatario>
    {
        public DestinatarioRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public async Task<int> GetIdDestinatarioAsync(string email)
        {
            return await _ctx.Destinatari.
                Where(x => x.Email.ToLower().Equals(email.ToLower())).
                Select(X => X.IdDestinatario).
                FirstOrDefaultAsync();
        }

        public async Task<List<Destinatario>> GetDestinatariAsync(List<int> ids)
        {
            return await _ctx.Destinatari.
                Where(x => ids.Contains(x.IdDestinatario)).
                ToListAsync();
        }
    }
}