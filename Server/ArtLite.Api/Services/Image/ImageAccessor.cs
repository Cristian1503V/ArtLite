// using ArtLite.Api.ServiceContracts;
// using ArtLite.Api.Settings;
// using CloudinaryDotNet;
// using CloudinaryDotNet.Actions;
// using Microsoft.Extensions.Options;

// namespace ArtLite.Api.Services;

// public class ImageAccessor : IImageAccessor
// {
//     private readonly Cloudinary _cloudinary;

//     public ImageAccessor(IOptions<CloudinarySettings> config)
//     {
//         var configValues = config.Value;

//         var account = new Account(
//             cloud: configValues.CloudName,
//             apiKey: configValues.ApiKey,
//             apiSecret: configValues.ApiSecret
//         );

//         _cloudinary = new Cloudinary(account);
//     }

//     public ImageUploadResponse AddImage(IFormFile file)
//     {
//         var uploadResult = new ImageUploadResult();

//         if (file.Length > 0)
//         {
//             using (var stream = file.OpenReadStream())
//             {
//                 var uploadParams = new ImageUploadParams
//                 {
//                     File = new FileDescription(file.FileName, stream)
//                 };

//                 uploadResult = _cloudinary.Upload(uploadParams);
//             }
//         }

//         if (uploadResult.Error != null)
//         {
//             throw new Exception(uploadResult.Error.Message);
//         }

//         return new ImageUploadResponse
//         {
//             PublicId = uploadResult.PublicId,
//             Url = uploadResult.SecureUrl.AbsoluteUri
//         };
//     }

//     public string DeleteImage(string publicId)
//     {
//         throw new NotImplementedException();
//     }
// }
