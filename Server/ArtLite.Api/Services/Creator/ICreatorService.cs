using ErrorOr;
using ArtLite.Api.Entities;

namespace ArtLite.Api.Services;

public interface ICreatorService
{
    Task<ErrorOr<Creator>> GetCreatorById(Guid id);
    Task<ErrorOr<Creator>> GetCreatorBySlug(string slug);
}
