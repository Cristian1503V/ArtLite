using ArtLite.Api.Entities;
using ArtLite.Api.Persistence;
using ArtLite.Api.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ArtLite.Api.Services;

public class ArtworkService : IArtworkService
{
    private readonly ApplicationDbContext _dbContext;

    public ArtworkService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<Artwork>> AddArtwork(Artwork newArtwork)
    {
        var tagsList = newArtwork.Tags
            .Select(tag => tag.TagName);

        if (tagsList is not null)
        {
            var selectedTags = _dbContext.Tags
                .Where(t => tagsList.Contains(t.TagName)).ToList();

            newArtwork.Tags = selectedTags;
        }

        await _dbContext.AddAsync(newArtwork);
        await _dbContext.SaveChangesAsync();

        return newArtwork;
    }

    public async Task<ErrorOr<Deleted>> DeleteArtwork(Guid id)
    {
        var artwork = await _dbContext.Artworks
            .FindAsync(id);

        if (artwork is null)
        {
            return ArtworkError.NotFound;
        }
        
        _dbContext.Remove(artwork);
        await _dbContext.SaveChangesAsync();

        return Result.Deleted;
    }

    public async Task<ErrorOr<Artwork>> GetArtworkById(Guid id)
    {
        var artwork = await _dbContext.Artworks
            .Include(a => a.Creator)
            .Include(a => a.Tags)
            .Include(a => a.Images)
            .SingleOrDefaultAsync(a => a.IdArtwork == id);


        if (artwork is null)
        {
            return ArtworkError.NotFound;
        }

        return artwork;
    }

    public async Task<ErrorOr<Artwork>> UpdateArtwork(Guid id, Artwork updatedArtwork)
    {
        var artwork = await _dbContext.Artworks
            .Include(a => a.Tags)
            .SingleOrDefaultAsync(a => a.IdArtwork == id);


        if (artwork is null)
        {
            return ArtworkError.NotFound;
        }

        var tagsList = updatedArtwork.Tags?.Select(tag => tag.TagName);

        if (tagsList is not null)
        {
            var selectedTags = _dbContext.Tags
                .Where(t => tagsList.Contains(t.TagName)).ToList();

            artwork.Tags = selectedTags;
        }

        artwork.Title = updatedArtwork.Title;
        artwork.Description = updatedArtwork.Description;

        await _dbContext.SaveChangesAsync();

        return artwork;
    }
}
