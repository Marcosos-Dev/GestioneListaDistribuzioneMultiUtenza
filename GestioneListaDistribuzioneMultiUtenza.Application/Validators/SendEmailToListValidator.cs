using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class SendEmailToListValidator : AbstractValidator<SendEmailToListRequest>
    {
        public SendEmailToListValidator()
        {
            RuleFor(l => l.Subject)
                .NotNull()
                .WithMessage("Il campo subject è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo subject è obbligatorio (vuoto)");
            RuleFor(l => l.Body)
                .NotNull()
                .WithMessage("Il campo page number è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo page number è obbligatorio (vuoto)");
            RuleFor(l => l.listId)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");
        }
    }
}
