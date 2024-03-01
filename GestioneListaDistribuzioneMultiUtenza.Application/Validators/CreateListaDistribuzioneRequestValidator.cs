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
                .WithMessage("Il campo nome lista è obbligatorio (vuoto)")
                .MinimumLength(3)
                .WithMessage("Il nome della lista deve essere lungo almeno 3 caratteri");
        }
    }
}
