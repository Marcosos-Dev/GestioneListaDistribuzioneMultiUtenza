using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class GetListaDistribuzioneByEmailValidator : AbstractValidator<GetListeUtenteByEmailRequest>
    {
        public GetListaDistribuzioneByEmailValidator()
        {
            RuleFor(l => l.PageSize)
                .NotNull()
                .WithMessage("Il campo page size è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo page size è obbligatorio (vuoto)")
                .LessThanOrEqualTo(0)
                .WithMessage("Il campo page size deve essere maggiore di 0");
            RuleFor(l => l.PageNumber)
                .NotNull()
                .WithMessage("Il campo page number è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo page number è obbligatorio (vuoto)")
                .LessThan(0)
                .WithMessage("Il campo page number deve essere positivo (almeno 0)");
            RuleFor(r => r.email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .WithRegEx("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", "email non valida");
        }
    }
}
