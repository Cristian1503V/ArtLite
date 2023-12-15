using ArtLite.Api.Contracts.Tag;
using ArtLite.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtLite.Api.Controllers;

[Route("/api/tags")]
public class TagController : ApiController
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    public async Task<IActionResult> GetAllTags ()
    {
        var getAllTagsResult = await _tagService.GetAllTags();

        return getAllTagsResult.Match(
            tags => Ok(MapTagResponse(tags)),
            errors => Problem(errors)
        );
    }


    private static TagResponse MapTagResponse(List<Tag> tags)
    {
        List<string> tagNames = tags.Select(t => t.TagName).ToList();

        return new TagResponse(Tags: tagNames);
    }
}
