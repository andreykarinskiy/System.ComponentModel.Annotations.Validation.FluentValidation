using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using Sуstem.ComponentModel.Annotations.Validation;
using IValidator = Sуstem.ComponentModel.Annotations.Validation.IValidator;

namespace ConsoleApp1
{
    public static class Extension
    {
        public static IValidator UseFluentValidator(this ObjectValidator validator, params FluentValidation.IValidator[] fluentValidators)
        {
            return new FluentValidatorAdapter(validator, fluentValidators);
        }
    }
}
