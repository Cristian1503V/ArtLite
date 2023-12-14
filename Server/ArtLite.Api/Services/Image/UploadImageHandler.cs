// using ArtLite.Api.Entities;
// using MediatR;

// namespace ArtLite.Api.Services;

// public class UploadImageHandler
// {
//     public class Command : IRequest<Image>
//     {
//         public required IFormFile File { get; set; }
//         public required Guid IdAccount { get; set; }
//     }

// public class Handler : IRequestHandler<Command, Image>
//     {
//         private readonly AppDbContext _dbContext;
//         private readonly IImageAccessor _imageAccessor;

//         public Handler(AppDbContext dbContext, IImageAccessor imageAccessor)
//         {
//             _dbContext = dbContext;
//             _imageAccessor = imageAccessor;
//         }

//         public async Task<Image> Handle(Command request, CancellationToken cancellationToken)
//         {
//             var imageUploadResult = _imageAccessor.AddImage(request.File);
    
//             // var account = await _dbContext.Account.SingleOrDefaultAsync(a => a.Id == request.IdAccount);

//             var image = new Image
//             {
//                 Src = imageUploadResult.Url,
//                 CloudId = imageUploadResult.
//             };

//             // if (account is null) throw new Exception("User not logged");
    

//             // account.ProfileImage = image.Src;

//             // var success = await _dbContext.SaveChangesAsync() > 0;

//             // if (success) return image;

//             // throw new Exception("Problem saving changes");
//         }
//     }
// }
