# Gestione di liste di distribuzione multiutenza
Realizzazione di una web api che permetta la gestione di una lista di distribuzione multiutenza.

L'applicazione deve avere un elenco di utenti con le seguenti proprietà :
- Email
- Nome 
- Cognome
- Password

Ogni utente puo' essere proprietario di una o più liste di distribuzione.
Ogni lista di distribuzione ha le seguenti proprietà :
- Nome della lista
- Proprietario
- una lista di Email Destinatarie

Le api che dovranno essere realizzate sono le seguenti :
 - Creazione di un utente (anonima senza autenticazione).
 - Autenticazione.
 - Creazione di una lista di distribuzione.
 - Aggiunta di un destinatario ad una lista di distribuzione.
 - Eliminazione di un destinatario da un lista di distribuzione.
 - Invio di una comunicazione ad una lista di distribuzione.
   Tramite questa chiamata dovrà partire una email a tutti i membri della lista di distribuzione
 - Dato un destinatario ottenere tutte le liste di distribuzione a lui associate
   La ricerca dovrà paginare i risultati, in base ad un parametro passato nella chiamata.	
     
Ogni utente può vedere solamente i dati delle liste di distribuzione di cui è proprietario.

## Operazioni preliminari per utilizzare l'applicazione

Prima di poter utilizzare l'applicazione è necessario avere un database SQL server e il relativo utente. Le credenziali di default (modificabili nel appsetting.json presente nel progetto Web) sono
```
Nome DB: DistribuzioneMultiUtenza
Utente: paradigmi
Password: paradigmi
```
Per creare il database è sufficiente eseguire lo script presente nella sezione successiva.

## Dump del database

Per avere una copia del database di test è sufficiente eseguire il file dump.sql presente nel repository.

_Altrimenti è sufficiente creare il database tramite il seguente script_

```
CREATE TABLE Utenti (
    IdUtente INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Cognome VARCHAR(255) NOT NULL,
    Password VARCHAR(30) NOT NULL
);

CREATE TABLE ListeDistribuzione (
    IdLista INT IDENTITY(1,1) PRIMARY KEY,
    IdProprietario INT,
    NomeLista VARCHAR(255) NOT NULL,
    FOREIGN KEY (IdProprietario) REFERENCES Utenti(IdUtente) ON DELETE CASCADE
);

CREATE TABLE Destinatari (
    IdDestinatario INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Liste_Destinatari (
    IdListaDestinatari INT IDENTITY(1,1) PRIMARY KEY,
    IdLista INT,
    IdDestinatario INT,
    FOREIGN KEY (IdLista) REFERENCES ListeDistribuzione(IdLista) ON DELETE CASCADE,
    FOREIGN KEY (IdDestinatario) REFERENCES Destinatari(IdDestinatario) ON DELETE CASCADE
);
```
## Utilizzare l'applicazione

L'utilizzo delle API avviene tramite swagger, per avviarlo è necessario impostare il modulo Web come progetto di avvio.
