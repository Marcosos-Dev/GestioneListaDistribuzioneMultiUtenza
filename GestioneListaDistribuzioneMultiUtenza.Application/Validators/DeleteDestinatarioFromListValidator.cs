using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class DeleteDestinatarioFromListValidator : AbstractValidator<DeleteListaDistribuzione_DestinatarioRequest>
    {
        public DeleteDestinatarioFromListValidator() 
        {
            RuleFor(l => l.idLista)
                .NotNull()
                .WithMessage("Il campo id lista è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il campo id lista è obbligatorio (vuoto)");
            RuleFor(r => r.email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (vuoto)")
                .WithRegEx("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", "email non valida");
        }
    }
}
