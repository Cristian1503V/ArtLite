namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkCreateRequest
(
    string Title,
    string Description,
    List<string> Tags,
    IFormFileCollection Images
);
