namespace ArtLite.Api.Contracts.Creator;

public record CreatorResponse
(
    Guid IdCreator,
    string Username,
    string Slug,
    string Email,
    string HighlightedPhrase,
    string Biography,
    SocialsResponse Socials,
    string ProfileImage,
    string ProfileBanner,
    List<ArtworkResponseBase> Artworks,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record SocialsResponse
(
    string Instagram,
    string Youtube,
    string Facebook,
    string Linkedin,
    string Figma
);

public record ArtworkResponseBase
(
    Guid IdArtwork,
    string Title,
    string Thumbnail,
    DateTime CreatedAt
);
