using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public async Task<Utente> GetUtenteByEmailPasswordAsync(string email, string password)
        {
            return await _ctx.Utenti.Where(u => u.Email.ToLower().Equals(email.ToLower()) && 
            u.Password.Equals(password)).FirstOrDefaultAsync();
        }
    }
}
