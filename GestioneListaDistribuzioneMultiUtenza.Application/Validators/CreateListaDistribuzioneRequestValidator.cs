using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class CreateListaDistribuzioneRequestValidator : AbstractValidator<CreateListaDistribuzioneRequest>
    {
        public CreateListaDistribuzioneRequestValidator() 
        {
            RuleFor(r => r.NomeLista)
                .NotNull()
                .WithMessage("Il campo nome lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo nome lista è obbligatorio (vuoto)");
        }
    }
}
