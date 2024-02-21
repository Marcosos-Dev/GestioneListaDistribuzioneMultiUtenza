using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator() 
        { 
            RuleFor(r=>r.Nome)
                .NotNull()
                .WithMessage("Il campo nome è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio (vuoto)")
                .MinimumLength(3)
                .WithMessage("Il nome deve essere lungo almeno 3 caratteri");

            RuleFor(r => r.Cognome)
                .NotNull()
                .WithMessage("Il campo cognome è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo cognome è obbligatorio (vuoto)")
                .MinimumLength(3)
                .WithMessage("Il cognome deve essere lungo almeno 3 caratteri");

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .WithRegEx("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", "email non valida");
                
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo password è obbligatorio (vuoto)")
                .WithRegEx("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z\\s])[a-zA-Z\\d\\S]{8,}$", "password non valida");
                //almeno 8 caratteri, almeno 1: maiuscolo, minuscolo, numero e speciale
        }
    }
}
