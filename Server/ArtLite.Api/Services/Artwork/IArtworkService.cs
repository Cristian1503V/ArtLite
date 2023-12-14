using ArtLite.Api.Entities;
using ErrorOr;

namespace ArtLite.Api.Services;

public interface IArtworkService
{
    Task<ErrorOr<Artwork>> GetArtworkById(Guid id);
    Task<ErrorOr<Artwork>> AddArtwork(Artwork newArtwork);
    Task<ErrorOr<Artwork>> UpdateArtwork(Guid id, Artwork updatedArtwork);
    Task<ErrorOr<Deleted>> DeleteArtwork(Guid id);
}
