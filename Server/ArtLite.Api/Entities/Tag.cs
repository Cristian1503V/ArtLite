using ArtLite.Api.Entities;

namespace ArtLite.Api;

public class Tag
{
    public Guid IdTag { get; set; }
    public string TagName { get; set; } = null!;


    public ICollection<Artwork> Artworks { get; set; } = null!;
}
