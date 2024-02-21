using FluentValidation;
using System.Text.RegularExpressions;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static void WithRegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage)
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regEx = new Regex(regex);
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    context.AddFailure(validationMessage);
                }
            });
        }
    }
}
