using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator() 
        {
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
        }
    }
}
