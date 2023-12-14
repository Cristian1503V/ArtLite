namespace ArtLite.Api.Contracts.Creator;

public record CreatorResponse
(
    Guid IdCreator,
    string Username,
    string Email,
    string HighlightedPhrase,
    string Biography,
    SocialsResponse Socials,
    string ProfileImage,
    List<ArtworkResponse> Artworks,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record SocialsResponse
(
    string Instagram,
    string Youtube,
    string Facebook,
    string Linkedin,
    string TikTok
);

public record ArtworkResponse
(
    Guid IdArtwork,
    string Title,
    string Thumbnail,
    DateTime CreatedAt
);
