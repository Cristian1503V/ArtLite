using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArtLite.Api.Entities;

public class Creator
{
    [Key]
    public Guid IdCreator { get; set; }
    public string Username { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string HighlightedPhrase { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string SocialInstagram { get; set; } = null!;
    public string SocialYoutube { get; set; } = null!;
    public string SocialFacebook { get; set; } = null!;
    public string SocialLinkedin { get; set; } = null!;
    public string SocialFigma { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public virtual ICollection<Artwork> Artworks { get; set; } = null!;
}
