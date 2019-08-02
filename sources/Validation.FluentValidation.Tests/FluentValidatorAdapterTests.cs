using System.ComponentModel.Annotations.Validation.FluentValidation.Tests.TestData;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sуstem.ComponentModel.Annotations.Validation;
using IValidator = FluentValidation.IValidator;

namespace System.ComponentModel.Annotations.Validation.FluentValidation.Tests
{
    [TestClass]
    public sealed class FluentValidatorAdapterTests
    {
        [TestMethod]
        public void FluentValidatorAdapter_must_work_as_ComponentModelValidator()
        {
            // Arrange
            var validator = new ObjectValidator();
            var sut = new FluentValidatorAdapter(validator, Enumerable.Empty<IValidator>());

            // Act
            var actual = sut.Validate(new ClassWithProperties());

            // Assert
            actual.Should().BeEquivalentTo(Expectation("The PropertyWithValidation field is required.", "PropertyWithValidation"));
        }

        [TestMethod]
        public void FluentValidator_and_ComponentModelValidator_must_work_together()
        {
            // Arrange
            var validator = new ObjectValidator();
            var fluentValidator = new ClassWithPropertiesValidator();
            var sut = new FluentValidatorAdapter(validator, new[] { fluentValidator });

            // Act
            var actual = sut.Validate(new ClassWithProperties());

            // Assert
            actual.Should().BeEquivalentTo(new object[]
            {
                Expectation("The PropertyWithValidation field is required.", "PropertyWithValidation"),
                Expectation("'Property With Validation' must not be empty.", "PropertyWithValidation")
            });
        }
        
        private ValidationResult Expectation(string message, string property)
        {
            return new ValidationResult(message, new[] {property});
        }
    }
}
