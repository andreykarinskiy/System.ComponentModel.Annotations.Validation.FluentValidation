using System.ComponentModel.Annotations.Validation.FluentValidation.Tests.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sуstem.ComponentModel.Annotations.Validation;

namespace System.ComponentModel.Annotations.Validation.FluentValidation.Tests
{
    [TestClass]
    public sealed class ObjectValidatorTests
    {
        [TestMethod]
        public void FluentValidator_adapter_can_be_attached_to_ObjectValidator()
        {
            // Arrange
            var fluentValidator = new ClassWithPropertiesValidator();

            // Act
            IValidator sut = new ObjectValidator()
                .UseFluentValidator(fluentValidator);

            // Assert
            sut.Should().BeOfType<FluentValidatorAdapter>();
        }
    }
}
