using ArtLite.Api.Entities;
using ArtLite.Api.ServiceContracts;
using ArtLite.Api.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace ArtLite.Api.Services;

public class CloudinaryService : IImageUploader
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> config)
    {
        var configValues = config.Value;

        var account = new Account(
            cloud: configValues.CloudName,
            apiKey: configValues.ApiKey,
            apiSecret: configValues.ApiSecret
        );

        _cloudinary = new Cloudinary(account);
    }

    public async Task<Image> AddImage(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
        }

        if (uploadResult.Error != null)
        {
            throw new Exception(uploadResult.Error.Message);
        }

        return new Image
        {
            CloudId = uploadResult.PublicId,
            Src = uploadResult.SecureUrl.AbsoluteUri
        };
    }

    public Task<bool> DeleteImage(string publicId)
    {
        throw new NotImplementedException();
    }
}
