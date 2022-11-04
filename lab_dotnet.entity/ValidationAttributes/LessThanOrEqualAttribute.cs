using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace lab_dotnet.entity.ValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
sealed public class LessThanOrEqualAttribute : ValidationAttribute
{
    /// <summary>
    /// holds date property name
    /// </summary>
    private string PropertyName { get; }

    /// <summary>
    /// constructor
    /// </summary>
    public LessThanOrEqualAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    /// <inheritdoc/>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult($"The field {validationContext.DisplayName} must be not null.");
        }

        PropertyInfo? info = validationContext.ObjectType.GetProperty(PropertyName);
        if (info == null)
        {
            return new ValidationResult($"No property {PropertyName} exists.");
        }

        object? biggerDate = info.GetValue(validationContext.ObjectInstance, null);
        if (biggerDate == null)
        {
            return new ValidationResult($"The field {PropertyName} must be not null.");
        }

        if (value is DateTime)
        {
            if (!(biggerDate is DateTime))
            {
                return new ValidationResult($"The field {PropertyName} must be of type DateTime.");
            }

            if ((DateTime)value > (DateTime)biggerDate)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be less than field {PropertyName}.");
            }
        }
        else if (value is int)
        {
            if (!(biggerDate is int))
            {
                return new ValidationResult($"The field {PropertyName} must be of type int.");
            }

            if ((int)value > (int)biggerDate)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be less than field {PropertyName}.");
            }
        }
        else
        {
            return new ValidationResult($"The field {validationContext.DisplayName} must be of type DateTime or int.");
        }

        return ValidationResult.Success;
    }
}