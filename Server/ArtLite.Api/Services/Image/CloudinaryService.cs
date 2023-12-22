using ArtLite.Api.Entities;
using ArtLite.Api.ServiceErrors;
using ArtLite.Api.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ErrorOr;
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

    public async Task<ErrorOr<Image>> AddImage(IFormFile file)
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
            return Errors.Image.Upload;
        }

        return new Image
        {
            CloudId = uploadResult.PublicId,
            Src = uploadResult.SecureUrl.AbsoluteUri
        };
    }

    public async Task<bool> DeleteImage(string publicId)
    {
        if (string.IsNullOrEmpty(publicId)) return false;

        var deleteParams = new DeletionParams(publicId);

        var result = await _cloudinary.DestroyAsync(deleteParams);

       return result.Result == "ok";
    }
}
