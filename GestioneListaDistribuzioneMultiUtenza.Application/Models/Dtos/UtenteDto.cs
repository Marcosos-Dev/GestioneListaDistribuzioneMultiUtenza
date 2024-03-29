﻿using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Models.Dtos
{
    public class UtenteDto
    {
        public UtenteDto() { }
        public UtenteDto(Utente utente)
        {
            Email = utente.Email;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
        }

        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
    }
}
