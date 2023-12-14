namespace ArtLite.Api.Contracts.Artwork;

public record ArtworkResponse
(
    Guid IdArtwork,
    string Title,
    string Description,
    List<string> Tags,
    List<ImageResponse> Images,
    CreatorResponse Creator,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record ImageResponse
(
    int Order,
    string Src
);

public record CreatorResponse
(
    Guid IdCreator,
    string Username,
    string ProfileImage
);