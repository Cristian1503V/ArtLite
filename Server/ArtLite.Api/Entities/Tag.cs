using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArtLite.Api.Entities;

namespace ArtLite.Api;

public class Tag
{
    [Key]
    public Guid IdTag { get; set; }
    public string TagName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Artwork> Artworks { get; set; } = null!;
}
