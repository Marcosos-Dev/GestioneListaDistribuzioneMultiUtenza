using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class SendEmailToListaRequestValidator : AbstractValidator<SendEmailToListaRequest>
    {
        public SendEmailToListaRequestValidator()
        {
            RuleFor(r => r.Subject)
                .NotNull()
                .WithMessage("Il campo subject è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo subject è obbligatorio (vuoto)");

            RuleFor(r => r.Body)
                .NotNull()
                .WithMessage("Il campo page number è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo page number è obbligatorio (vuoto)");

            RuleFor(r => r.idLista)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");
        }
    }
}
