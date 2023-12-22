using System.ComponentModel.DataAnnotations;

namespace ArtLite.Api.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class TagsMaxItemsValidation : ValidationAttribute
{
    private readonly int _maxItems;

    public TagsMaxItemsValidation(int maxItems)
    {
        _maxItems = maxItems;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not List<string> list || list.Count > _maxItems)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}