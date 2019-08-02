using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sуstem.ComponentModel.Annotations.Validation;
using IFluentValidator = FluentValidation.IValidator;

namespace System.ComponentModel.Annotations.Validation.FluentValidation
{
    internal sealed class FluentValidatorAdapter : IValidator
    {
        private readonly IValidator adaptable;
        private readonly IEnumerable<IFluentValidator> fluentValidators;

        public FluentValidatorAdapter(IValidator adaptable, IEnumerable<IFluentValidator> fluentValidators)
        {
            this.adaptable = adaptable;
            this.fluentValidators = fluentValidators;
        }

        public IEnumerable<ValidationResult> Validate(object source)
        {
            foreach (var validationResult in adaptable.Validate(source))
            {
                yield return validationResult;
            }

            foreach (var fluentValidator in fluentValidators)
            {
                foreach (var fluentResult in fluentValidator.Validate(source).Errors)
                {
                    yield return new ValidationResult(fluentResult.ErrorMessage, new[] { fluentResult.PropertyName });
                }
            }
        }
    }
}
