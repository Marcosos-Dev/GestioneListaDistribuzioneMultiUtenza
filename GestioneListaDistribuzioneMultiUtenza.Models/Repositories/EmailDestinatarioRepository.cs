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

        public void addEmailWithList(EmailDestinatario e, ListaDistribuzione l)
        {
            _ctx.EmailDest.Add(e);
            this.Save();
            ListaDistribuzione_Email collegamento = new ListaDistribuzione_Email();
            collegamento.IdLista = l.IdLista;
            collegamento.IdEmailDestinatario = e.IdEmailDestinatario;
            _ctx.UnioneLista_Destinatari.Add(collegamento);
            this.Save();
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
            var idListe = _ctx.UnioneLista_Destinatari.
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
