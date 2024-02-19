// See https://aka.ms/new-console-template for more information
using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;
using Microsoft.EntityFrameworkCore;

MyDbContext ctx = new MyDbContext();

var utenteRepo = new UtenteRepository(ctx);
var utente1 = new Utente();
var utente2 = new Utente();
var utente3 = new Utente();
utente1.nome = "Antonio";
utente1.cognome = "Binocolo";
utente1.email = "antonio.binocolo@gmail.com";
utente1.password = "123456";

utente2.nome = "Gino";
utente2.cognome = "Santo";
utente2.email = "gino.santo@gmail.com";
utente2.password = "654321";

utente3.nome = "Laura";
utente3.cognome = "Perlana";
utente3.email = "laura.perlana@gmail.com";
utente3.password = "abcdefg";

utenteRepo.Aggiungi(utente1);
utenteRepo.Aggiungi(utente2);
utenteRepo.Aggiungi(utente3);
utenteRepo.Save();

var listaRepo = new ListaDistribuzioneRepository(ctx);
var lista1 = new ListaDistribuzione();
var lista2 = new ListaDistribuzione();

lista1.nomeLista = "comunicando";
lista1.IdProprietario = 1;

lista2.nomeLista = "gingilli";
lista2.IdProprietario = 2;

listaRepo.Aggiungi(lista1);
listaRepo.Aggiungi(lista2);
listaRepo.Save();

var emailRepo = new EmailDestinatarioRepository(ctx);
var email1 = new EmailDestinatario();
var email2 = new EmailDestinatario();
var email3 = new EmailDestinatario();
var email4 = new EmailDestinatario();

email1.email = "first@gmail.com";
email2.email = "second@gmail.com";
email3.email = "third@gmail.com";
email4.email = "fourth@gmail.com";

emailRepo.Aggiungi(email1);
emailRepo.Aggiungi(email2);
emailRepo.Aggiungi(email3);
emailRepo.Aggiungi(email4);
emailRepo.Save();

var lista_dest_Repo = new ListaDestinatariRepository(ctx);
var info1 = new ListaDist_Destinatario();
var info2 = new ListaDist_Destinatario();
var info3 = new ListaDist_Destinatario();
var info4 = new ListaDist_Destinatario();

info1.IdLista = 1;
info1.IdEmailDestinatario = 1;

info2.IdLista = 1;
info2.IdEmailDestinatario = 3;

info3.IdLista = 3;
info3.IdEmailDestinatario = 3;

info4.IdLista = 3;
info4.IdEmailDestinatario = 4;

lista_dest_Repo.Aggiungi(info1);
lista_dest_Repo.Aggiungi(info2);
lista_dest_Repo.Aggiungi(info3);
lista_dest_Repo.Aggiungi(info4);
lista_dest_Repo.Save();