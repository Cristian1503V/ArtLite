using ArtLite.Api.Controllers;
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCreator (Guid id)
    {
        var getCreatorByIdResult = await _creatorService.GetCreatorById(id);

        return getCreatorByIdResult.Match(
            creator => Ok(creator),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:string}")]
    public async Task<IActionResult> GetCreator (string id)
    {
        var getCreatorByIdResult = await _creatorService.GetCreatorBySlug(id);

        return getCreatorByIdResult.Match(
            creator => Ok(creator),
            errors => Problem(errors)
        );
    }
}
