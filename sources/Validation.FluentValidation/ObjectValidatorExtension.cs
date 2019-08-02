using Sуstem.ComponentModel.Annotations.Validation;
using IFluentValidator = FluentValidation.IValidator;

namespace System.ComponentModel.Annotations.Validation.FluentValidation
{
    public static class ObjectValidatorExtension
    {
        public static IValidator UseFluentValidator(this ObjectValidator validator, params IFluentValidator[] fluentValidators)
        {
            return new FluentValidatorAdapter(validator, fluentValidators);
        }
    }
}
