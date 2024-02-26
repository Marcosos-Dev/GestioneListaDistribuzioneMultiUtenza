using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public class EmailDestinatarioRepository : GenericRepository<EmailDestinatario>
    {
        public EmailDestinatarioRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public int OttieniIdFromEmail(string email)
        {
            return _ctx.EmailDestinatarie.
                Where(x => x.Email.ToLower().Equals(email.ToLower())).
                Select(X => X.IdEmailDestinatario).
                FirstOrDefault();
        }
    }
}
