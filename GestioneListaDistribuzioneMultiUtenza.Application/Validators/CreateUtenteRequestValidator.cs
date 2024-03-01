using FluentValidation;
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
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .Matches("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$")
                .WithMessage("email non valida");

            RuleFor(r => r.Password)
                .NotNull()
                .WithMessage("Il campo password è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio (vuoto)")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z\\s])[a-zA-Z\\d\\S]{8,}$")
                .WithMessage("password non valida, almeno 8 caratteri tra cui almeno 1: maiuscolo, minuscolo, numero e speciale");
        }
    }
}
