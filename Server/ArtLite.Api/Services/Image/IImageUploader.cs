using ArtLite.Api.Entities;
using ErrorOr;

namespace ArtLite.Api.Services;

public interface IImageUploader
{
    Task<ErrorOr<Image>> AddImage(IFormFile file);
    Task<bool> DeleteImage(string publicId);
}
