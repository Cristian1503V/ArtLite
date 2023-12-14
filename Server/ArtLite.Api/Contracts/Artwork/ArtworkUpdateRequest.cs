namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkUpdateRequest
(
    string Title,
    string Description,
    List<string> Tags
);

