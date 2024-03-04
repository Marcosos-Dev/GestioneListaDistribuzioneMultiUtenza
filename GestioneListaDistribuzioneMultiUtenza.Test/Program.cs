// See https://aka.ms/new-console-template for more information
using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;
using Microsoft.EntityFrameworkCore;


/*MyDbContext ctx = new MyDbContext();
var emailRepo = new DestinatarioRepository(ctx);
foreach (var destinatari in await emailRepo.GetDestinatariAsync(2))
{
    Console.WriteLine(destinatari.Email);
}*/
/*MyDbContext ctx = new MyDbContext();
var listaRepo = new ListaDistribuzioneRepository(ctx);
var liste = listaRepo.testmethod(1, "va");
foreach (var lista in liste)
{
    Console.WriteLine(lista.NomeLista);
    foreach (var lista_destinatario in lista.Destinatari)
    {
        Console.WriteLine("   " + lista_destinatario.Destinatario.Email);
    }
}
Console.ReadLine();*/
/*MyDbContext ctx = new MyDbContext();
var utenteRepo = new UtenteRepository(ctx);
var utente1 = new Utente();
utente1.Nome = "Antonio";
utente1.Cognome = "Binocolo";
utente1.Email = "antonio.binocolo@gmail.com";
utente1.Password = "123456";
await utenteRepo.AggiungiAsync(utente1);
await utenteRepo.SaveAsync();*/
/*var utenteRepo = new UtenteRepository(ctx);
var utente1 = new Utente();
var utente2 = new Utente();
var utente3 = new Utente();
utente1.Nome = "Antonio";
utente1.Cognome = "Binocolo";
utente1.Email = "antonio.binocolo@gmail.com";
utente1.Password = "123456";

utente2.Nome = "Gino";
utente2.Cognome = "Santo";
utente2.Email = "gino.santo@gmail.com";
utente2.Password = "654321";

utente3.Nome = "Laura";
utente3.Cognome = "Perlana";
utente3.Email = "laura.perlana@gmail.com";
utente3.Password = "abcdefg";

utenteRepo.Aggiungi(utente1);
utenteRepo.Save();
utenteRepo.Aggiungi(utente2);
utenteRepo.Save();
utenteRepo.Aggiungi(utente3);
utenteRepo.Save();

var listaRepo = new ListaDistribuzioneRepository(ctx);
var lista1 = new ListaDistribuzione();
var lista2 = new ListaDistribuzione();

lista1.NomeLista = "comunicando";
lista1.IdProprietario = 1;

lista2.NomeLista = "gingilli";
lista2.IdProprietario = 2;

listaRepo.Aggiungi(lista1);
listaRepo.Save();
listaRepo.Aggiungi(lista2);
listaRepo.Save();

var emailRepo = new EmailDestinatarioRepository(ctx);
var email1 = new EmailDestinatario();
var email2 = new EmailDestinatario();
var email3 = new EmailDestinatario();
var email4 = new EmailDestinatario();

email1.Email = "first@gmail.com";
email2.Email = "second@gmail.com";
email3.Email = "third@gmail.com";
email4.Email = "fourth@gmail.com";

emailRepo.Aggiungi(email1);
emailRepo.Save();
emailRepo.Aggiungi(email2);
emailRepo.Save();
emailRepo.Aggiungi(email3);
emailRepo.Save();
emailRepo.Aggiungi(email4);
emailRepo.Save();

var lista_dest_Repo = new ListaDestinatariRepository(ctx);
var info1 = new ListaDistribuzione_Email();
var info2 = new ListaDistribuzione_Email();
var info3 = new ListaDistribuzione_Email();
var info4 = new ListaDistribuzione_Email();

info1.IdLista = 1;
info1.IdEmailDestinatario = 1;

info2.IdLista = 1;
info2.IdEmailDestinatario = 3;

info3.IdLista = 2;
info3.IdEmailDestinatario = 3;

info4.IdLista = 2;
info4.IdEmailDestinatario = 4;

lista_dest_Repo.Aggiungi(info1);
lista_dest_Repo.Save();
lista_dest_Repo.Aggiungi(info2);
lista_dest_Repo.Save();
lista_dest_Repo.Aggiungi(info3);
lista_dest_Repo.Save();
lista_dest_Repo.Aggiungi(info4);
lista_dest_Repo.Save();

var emailRepo = new EmailDestinatarioRepository(ctx);

var res = emailRepo.getListaByEmail("third@gmail.com");

var listaTemp = new ListaDistribuzione();
listaTemp.IdLista = 1;

var emailTemp = new EmailDestinatario();
emailTemp.Email = "fifth@gmail.com";

emailRepo.addEmailWithList(emailTemp, listaTemp);
emailRepo.Elimina(5);
emailRepo.Save();*/

Console.ReadLine();