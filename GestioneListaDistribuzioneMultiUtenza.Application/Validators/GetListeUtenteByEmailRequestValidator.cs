using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class GetListeUtenteByEmailRequestValidator : AbstractValidator<GetListeUtenteByEmailRequest>
    {
        public GetListeUtenteByEmailRequestValidator()
        {
            RuleFor(r => r.PageSize)
                .NotNull()
                .WithMessage("Il campo page size è obbligatorio (nullo)")
                .GreaterThan(0)
                .WithMessage("Il campo page size deve essere maggiore di 0");

            RuleFor(r => r.PageNumber)
                .NotNull()
                .WithMessage("Il campo page number è obbligatorio (nullo)")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Il campo page number deve essere almeno 0");
        }
    }
}
