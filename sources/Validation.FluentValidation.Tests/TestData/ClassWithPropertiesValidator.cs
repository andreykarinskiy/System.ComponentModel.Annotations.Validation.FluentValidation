using FluentValidation;

namespace System.ComponentModel.Annotations.Validation.FluentValidation.Tests.TestData
{
    public sealed class ClassWithPropertiesValidator : AbstractValidator<ClassWithProperties>
    {
        public ClassWithPropertiesValidator()
        {
            ValidatorOptions.LanguageManager.Enabled = false;

            RuleFor(o => o.PropertyWithValidation).MaximumLength(10);
        }
    }
}
