namespace ArtLite.Api.Entities;

public class Creator
{
    public Guid IdCreator { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string HighlightedPhrase { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string SocialInstagram { get; set; } = null!;
    public string SocialYoutube { get; set; } = null!;
    public string SocialFacebook { get; set; } = null!;
    public string SocialLinkedin { get; set; } = null!;
    public string SocialTiktok { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


    public ICollection<Artwork> Artworks { get; set; } = null!;
}
