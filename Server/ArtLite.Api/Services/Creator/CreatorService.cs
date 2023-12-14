using ArtLite.Api.Entities;
using ArtLite.Api.Persistence;
using ArtLite.Api.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ArtLite.Api.Services;

public class CreatorService : ICreatorService
{
    private readonly ApplicationDbContext _dbContext;

    public CreatorService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<Creator>> GetCreatorById(Guid id)
    {
        var creator = await _dbContext.Creators
            .Include(c => c.Artworks)
            .ThenInclude(a => a.Images)
            .SingleOrDefaultAsync(c => c.IdCreator == id);

        if (creator is null)
        {
            return CreatorError.NotFound;
        }

        return creator;
    }

    public async Task<ErrorOr<Creator>> GetCreatorBySlug(string slug)
    {
        var creator = await _dbContext.Creators
            .Include(c => c.Artworks)
            .ThenInclude(a => a.Images)
            .SingleOrDefaultAsync(c => c.Slug == slug);

        if (creator is null)
        {
            return CreatorError.NotFound;
        }

        return creator;
    }
}
