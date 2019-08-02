using System.ComponentModel.DataAnnotations;

namespace System.ComponentModel.Annotations.Validation.FluentValidation.Tests.TestData
{
    public sealed class ClassWithProperties
    {
        [Required]
        public string PropertyWithValidation { get; set; }
    }
}
