using System.ComponentModel.DataAnnotations;
using ArtLite.Api.Validations;

namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkCreateRequest
(
    [MinLength(4), MaxLength(30)] string Title,
    [MaxLength(200)] string Description,
    [TagsMaxItemsValidation(10, ErrorMessage = "The Tags list cannot contain more than 10 items.")]
    List<string> Tags,
    [ImageCollectionValidation(ErrorMessage = "One or more images are not valid.")]
    IFormFileCollection Images
);
