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
            var utente = await this.GetUtenteByEmailAsync(email);
            if(utente != null && utente.Password.Equals(password))
            {
                return utente;
            }
            return null;
        }

        public async Task<Utente> GetUtenteByEmailAsync(string email)
        {
            return await _ctx.Utenti.
                Where(u => u.Email.ToLower().Equals(email.ToLower())).FirstOrDefaultAsync();
        }
    }
}
