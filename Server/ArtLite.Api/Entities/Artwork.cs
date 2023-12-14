namespace ArtLite.Api.Entities;

public class Artwork
{
    public Guid IdArtwork { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


    public Guid IdCreator { get; set; }
    public Creator Creator { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = null!;
}
