using ArtLite.Api.Persistence;
using ArtLite.Api.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ArtLite.Api.Services;

public class TagService : ITagService
{
    private readonly ApplicationDbContext _dbContext;

    public TagService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<List<Tag>>> GetAllTags()
    {
        var tags = await _dbContext.Tags.ToListAsync();

        if (tags is null)
        {
            return TagError.NotFound;
        }

        return tags;
    }
}
