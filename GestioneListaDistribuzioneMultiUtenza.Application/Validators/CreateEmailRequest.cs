using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Validators
{
    public class CreateEmailRequest : AbstractValidator<DeleteListaDistribuzione_EmailRequest>
    {
        public CreateEmailRequest() 
        {
            RuleFor(r => r.listId)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (vuoto)");

            RuleFor(r => r.emailId)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio (nullo)")
                .NotNull()
                .WithMessage("Il campo email è obbligatorio (vuoto)");  
        }
        
    }
}
