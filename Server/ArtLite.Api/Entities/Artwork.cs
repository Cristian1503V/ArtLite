using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArtLite.Api.Entities;

public class Artwork
{
    [Key]
    public Guid IdArtwork { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


    public Guid CreatorId { get; set; }
    public Creator Creator { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Tag> Tags { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Image> Images { get; set; } = null!;
}
