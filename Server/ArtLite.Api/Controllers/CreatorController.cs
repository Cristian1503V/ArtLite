using ArtLite.Api.Contracts.Artwork;
using ArtLite.Api.Contracts.Creator;
using ArtLite.Api.Entities;
using ArtLite.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtLite.Api.Controllers;

[Route("api/creators")]
public class CreatorController : ApiController
{
    private readonly ICreatorService _creatorService;

    public CreatorController(ICreatorService creatorService)
    {
        _creatorService = creatorService;
    }

    // [HttpGet("{id:guid}")]
    // public async Task<IActionResult> GetCreator (Guid id)
    // {
    //     var getCreatorByIdResult = await _creatorService.GetCreatorById(id);

    //     return getCreatorByIdResult.Match(
    //         creator => Ok(creator),
    //         errors => Problem(errors)
    //     );
    // }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetCreator (string slug)
    {
        var getCreatorByIdResult = await _creatorService.GetCreatorBySlug(slug);

        return getCreatorByIdResult.Match(
            creator => Ok(MapCreatorResponse(creator)),
            errors => Problem(errors)
        );
    }

    private static CreatorResponse MapCreatorResponse(Creator creator)
    {
        var socials = new SocialsResponse (
            Instagram: creator.SocialInstagram,
            Youtube: creator.SocialYoutube,
            Facebook: creator.SocialFacebook,
            Linkedin: creator.SocialLinkedin,
            Figma: creator.SocialFigma
        );

        var artworks = creator.Artworks
            .Select(a => new ArtworkResponseBase (
                IdArtwork: a.IdArtwork,
                Title: a.Title,
                Thumbnail: a.Images?.SingleOrDefault(i => i.Order == 1)?.Src ?? "",
                CreatedAt: a.CreatedAt
            )).ToList();


        return new CreatorResponse (
            IdCreator: creator.IdCreator,
            Username: creator.Username,
            Slug: creator.Slug,
            Email: creator.Email,
            HighlightedPhrase: creator.HighlightedPhrase,
            Biography: creator.Biography,
            Socials: socials,
            ProfileImage: creator.ProfileImage,
            ProfileBanner: creator.ProfileBanner,
            Artworks: artworks,
            CreatedAt: creator.CreatedAt,
            UpdatedAt: creator.UpdatedAt
        );
    }



}
