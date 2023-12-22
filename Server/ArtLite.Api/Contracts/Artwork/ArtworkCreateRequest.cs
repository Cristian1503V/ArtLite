using System.ComponentModel.DataAnnotations;
using ArtLite.Api.Validations;

namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkCreateRequest
(
    [MinLength(4), MaxLength(30)] string Title,
    [MaxLength(200)] string Description,
    List<string> Tags,
    [ImageCollectionValidation(ErrorMessage = "Una o varias de las imágenes no son válidas")]
    IFormFileCollection Images
);
