
using ArtLite.Api.Contracts.Artwork;
using ArtLite.Api.Entities;
using ArtLite.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtLite.Api.Controllers;

[Route("api/artworks")]
public class ArtworkController : ApiController
{
    private readonly IArtworkService _artworkService;
    private readonly IImageUploader _imageUploader;

    private readonly Guid idCreatorExample = Guid.Parse("d53570c7-8651-4fc6-9cce-15848be6f289"); 

    public ArtworkController(IArtworkService artworkService, IImageUploader imageUploader)
    {
        _artworkService = artworkService;
        _imageUploader = imageUploader;
    }

    [HttpPost]
    [RequestSizeLimit(25 * 1024 * 1024)]
    public async Task<IActionResult> AddArtwork([FromForm] ArtworkCreateRequest artworkCreateRequest)
    {
        var uploadedImages = new List<Image>();

        var images = artworkCreateRequest.Images.ToList();

        if (images.Count < 1)
        {

        }

        foreach(var image in images)
        {
            int index = images.IndexOf(image);

            var uploadedImage = await _imageUploader.AddImage(file: image);

            if (uploadedImage.IsError)
            {
                return Problem(uploadedImage.Errors);
            }

            uploadedImage.Value.Order = index + 1;
            uploadedImages.Add(uploadedImage.Value);
        }

        var artwork = MapArtworkRequest(artworkCreateRequest);
        artwork.Images = uploadedImages;
        artwork.CreatorId = idCreatorExample;

        var addArtworkResult = await _artworkService.AddArtwork(artwork);

        return addArtworkResult.Match(
            artwork => CreatedAtAction(artwork),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetArtwork(Guid id)
    {   
        var getArtworkByIdResult = await _artworkService.GetArtworkById(id);

        return getArtworkByIdResult.Match(
            artwork => Ok(MapArtworkResponse(artwork)),
            errors => Problem(errors)
        );
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateArtwork(Guid id, ArtworkUpdateRequest artworkUpdateRequest)
    {   
        var artwork = MapArtworkRequest(artworkUpdateRequest);

        var getArtworkByIdResult = await _artworkService.UpdateArtwork(id, artwork);

        return getArtworkByIdResult.Match(
            artwork => Ok(MapArtworkResponse(artwork)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteArtwork(Guid id)
    {   
        var getArtworkByIdResult = await _artworkService.DeleteArtwork(id);

        return getArtworkByIdResult.Match(
            artwork => NoContent(),
            errors => Problem(errors)
        );
    }

    
    private static Artwork MapArtworkRequest(ArtworkCreateRequest artworkCreateRequest)
    {
        var tags = artworkCreateRequest.Tags
            .Select(tag => new Tag { TagName = tag }).ToList();

        return new Artwork {
            Title = artworkCreateRequest.Title,
            Description = artworkCreateRequest.Description,
            Tags = tags
        };
    }

    private static Artwork MapArtworkRequest(ArtworkUpdateRequest artworkUpdateRequest)
    {
        var tags = artworkUpdateRequest.Tags
            .Select(tag => new Tag { TagName = tag }).ToList();

        return new Artwork {
            Title = artworkUpdateRequest.Title,
            Description = artworkUpdateRequest.Description,
            Tags = tags
        };
    }

    private static ArtworkResponse MapArtworkResponse(Artwork artwork)
    {
        var images = artwork.Images
            .Select(image => new ImageResponse ( Src: image.Src, Order: image.Order )).ToList();

        var tags = artwork.Tags
            .Select(tag => tag.TagName).ToList();

        var creator = new CreatorResponseBase (
            IdCreator: artwork.Creator.IdCreator,
            Username: artwork.Creator.Username,
            Slug: artwork.Creator.Slug,
            ProfileImage: artwork.Creator.ProfileImage
        );
            
        return new ArtworkResponse (
            IdArtwork: artwork.IdArtwork,
            Title: artwork.Title,
            Description: artwork.Description,
            Tags: tags,
            Images: images,
            Creator: creator,
            CreatedAt: artwork.CreatedAt,
            UpdatedAt: artwork.UpdatedAt
        );
    }

    private IActionResult CreatedAtAction(Artwork artwork)
    {
        return CreatedAtAction(
            actionName: nameof(GetArtwork),
            routeValues: new { id = artwork.IdArtwork },
            value: MapArtworkResponse(artwork)
        );
    }

}
