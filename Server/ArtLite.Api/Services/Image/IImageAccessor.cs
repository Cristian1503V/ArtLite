using ArtLite.Api.Entities;
using ArtLite.Api.ServiceContracts;

namespace ArtLite.Api.Services;

public interface IImageAccessor
{
    Task<Image> AddImage(IFormFile file);
    string DeleteImage(string publicId);
}
