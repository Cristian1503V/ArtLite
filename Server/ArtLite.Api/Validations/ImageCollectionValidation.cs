using System.ComponentModel.DataAnnotations;

namespace ArtLite.Api.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class ImageCollectionValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFileCollection images || !images.Any())
        {
            return new ValidationResult(ErrorMessage);
        }

        foreach (var image in images)
        {
            if (!IsImageValid(image))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }

    private static bool IsImageValid(IFormFile image)
    {
        // Check if the file is not empty
        if (image.Length == 0)
        {
            return false;
        }

        // Check file size
        const int maxFileSize = 5 * 1024 * 1024; // 5 MB
        if (image.Length > maxFileSize)
        {
            return false;
        }

        // Check file type
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".avif", ".tiff" };
        var fileExtension = Path.GetExtension(image.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
        {
            return false;
        }

        // Check the content type as well
        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/avif", "image/webp" };
        if (!allowedContentTypes.Contains(image.ContentType.ToLower()))
        {
            return false;
        }

        return true;
    }
}
