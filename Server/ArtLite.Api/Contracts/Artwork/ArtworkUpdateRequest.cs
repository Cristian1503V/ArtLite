using System.ComponentModel.DataAnnotations;

namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkUpdateRequest
(
    [MinLength(4), MaxLength(30)] string Title,
    [MaxLength(200)] string Description,
    List<string> Tags
);

