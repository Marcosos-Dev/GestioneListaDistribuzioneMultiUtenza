using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class DeleteDestinatarioFromListValidator : AbstractValidator<DeleteListaDistribuzione_DestinatarioRequest>
    {
        public DeleteDestinatarioFromListValidator() 
        {
            RuleFor(l => l.listId)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");
            RuleFor(l => l.emailId)
                .NotNull()
                .WithMessage("Il campo id email è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id email è obbligatorio (vuoto)");
        }
    }
}
