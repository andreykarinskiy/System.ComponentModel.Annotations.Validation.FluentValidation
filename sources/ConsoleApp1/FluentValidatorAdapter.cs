using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sуstem.ComponentModel.Annotations.Validation;

namespace ConsoleApp1
{
    internal sealed class FluentValidatorAdapter : IValidator
    {
        private readonly IValidator decorated;
        private readonly FluentValidation.IValidator[] fluentValidators;

        public FluentValidatorAdapter(IValidator decorated, FluentValidation.IValidator[] fluentValidators)
        {
            this.decorated = decorated;
            this.fluentValidators = fluentValidators;
        }

        public IEnumerable<ValidationResult> Validate(object source)
        {
            foreach (var validationResult in decorated.Validate(source))
            {
                yield return validationResult;
            }

            foreach (var fluentValidator in fluentValidators)
            {
                foreach (var fluentResult  in fluentValidator.Validate(source).Errors)
                {
                    yield return new ValidationResult(fluentResult.ErrorMessage, new []{ fluentResult.PropertyName });
                }
            }
        }
    }
}
