using System.ComponentModel.DataAnnotations;

namespace ArtLite.Api.Entities;

public class Image
{
    [Key]
    public Guid IdImage { get; set; }
    public string CloudId { get; set; } = null!;
    public string Src { get; set; } = null!;
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }


    public Guid ArtworkId { get; set; }
    public Artwork Artwork { get; set; } = null!;
}
