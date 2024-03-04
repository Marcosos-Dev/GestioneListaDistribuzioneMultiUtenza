﻿using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class AddListaDistribuzione_DestinatarioRequestValidator : AbstractValidator<AddListaDistribuzione_DestinatarioRequest>
    {
        public AddListaDistribuzione_DestinatarioRequestValidator() 
        {
            RuleFor(r => r.idLista)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");

            RuleFor(r => r.email)
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .Matches("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$")
                .WithMessage("email non valida");
        }
    }
}
