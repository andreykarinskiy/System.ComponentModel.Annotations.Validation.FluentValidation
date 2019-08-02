![](icon.png)

# System.ComponentModel.Annotations.Validation.FluentValidation



### Overview

FluentValidation adapter to System.ComponentModel.Annotations.Validation library.



### Usage

Domain classes contain properties with validation attributes.

```c#
public sealed class ClassWithProperties
{
	[Required]
	public string PropertyWithValidation { get; set; }
}
```

Create FluentValidation validator.
```c#
public sealed class ClassWithPropertiesValidator : AbstractValidator<ClassWithProperties>
{
	public ClassWithPropertiesValidator()
	{
		RuleFor(o => o.PropertyWithValidation).MaximumLength(10);
	}
}
```

Next, the validator checks the domain class instance, and System.ComponentModel.Annotations.Validator and FluentValidator work together.

```c#
var source = new ClassWithProperties();
var fluentValidator = new ClassWithPropertiesValidator();

IValidator validator = new ObjectValidator()
	.UseFluentValidator(fluentValidator);

IEnumerable<ValidationResult> result = validator.Validate(source);
```



### Requirements

Depends to *System.ComponentModel.Annotations* and *System.ComponentModel.Annotations.Validation*.



### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
