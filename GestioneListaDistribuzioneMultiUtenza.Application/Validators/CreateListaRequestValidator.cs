using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class CreateListaRequestValidator : AbstractValidator<CreateListaDistribuzioneRequest>
    {
        public CreateListaRequestValidator() 
        {
            RuleFor(l => l.NomeLista)
                .NotNull()
                .WithMessage("Il campo nome lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo nome lista è obbligatorio (vuoto)");
        }
    }
}
