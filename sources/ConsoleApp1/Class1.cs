using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sуstem.ComponentModel.Annotations.Validation;
using IFluentValidator = FluentValidation.IValidator;

namespace ConsoleApp1
{
    public sealed class Class1
    {
        public static void Main(string[] args)
        {
            var person = new Person();

            var fluentValidator = new PersonValidator();
            var results = fluentValidator.Validate(person);


            var objValidator = new ObjectValidator().UseFluentValidator(fluentValidator);
            var results2 = objValidator.Validate(person).ToArray();

        }
    }

    public sealed class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).Must(BeValidName).WithMessage("must be correct name!");
        }

        private bool BeValidName(string name)
        {
            return false;
        }
    }

   
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Invariant("name must be correct!")]
        private bool NameCorrect()
        {
            return false;
        }
    }
}
