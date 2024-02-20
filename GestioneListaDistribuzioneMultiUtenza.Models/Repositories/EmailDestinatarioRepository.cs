﻿using GestioneListaDistribuzioneMultiUtenza.Models.Context;
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

        /*Dato un destinatario ottenere tutte le liste di distribuzione a lui associate
        La ricerca dovrà paginare i risultanti, in base ad un parametro passato nella chiamata*/
        public List<ListaDistribuzione> getListaByEmail(string email)
        {
            //TODO PAGINARE

            //Seleziono le email destinatarie che mi interessano
            var idEmail = _ctx.EmailDest.
                Where(x => x.Email.Equals(email))
                .First();
            //Prendo gli id delle liste collegate alla mail
            var idListe = _ctx.ListaDestinatari.
                Where(l => l.IdEmailDestinatario == idEmail.IdEmailDestinatario).
                Select(l => l.IdLista).
                ToList();
            //ritorno tutte le liste desiderate
            return _ctx.ListaDistribuzione.
                Where(i => idListe.Contains(i.IdLista))
                .ToList(); ;
        }
    }
}
