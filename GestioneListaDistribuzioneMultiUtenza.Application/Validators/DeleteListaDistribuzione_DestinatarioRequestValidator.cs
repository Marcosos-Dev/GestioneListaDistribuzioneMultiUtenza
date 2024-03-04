using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class DeleteListaDistribuzione_DestinatarioRequestValidator : AbstractValidator<DeleteListaDistribuzione_DestinatarioRequest>
    {
        public DeleteListaDistribuzione_DestinatarioRequestValidator() 
        {
            RuleFor(r => r.IdLista)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");

            RuleFor(r => r.Email)
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .Matches("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$")
                .WithMessage("email non valida");
        }
    }
}
