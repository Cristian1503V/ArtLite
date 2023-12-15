using ArtLite.Api.Entities;
using ArtLite.Api.Persistence;
using ArtLite.Api.ServiceErrors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ArtLite.Api.Services;

public class ArtworkService : IArtworkService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IImageUploader _imageUploader;

    public ArtworkService(ApplicationDbContext dbContext, IImageUploader imageUploader)
    {
        _dbContext = dbContext;
        _imageUploader = imageUploader;
    }

    public async Task<ErrorOr<Artwork>> AddArtwork(Artwork newArtwork)
    {
        var creator = await _dbContext.Creators
            .SingleOrDefaultAsync(c => c.IdCreator == newArtwork.CreatorId);

        if (creator is null)
        {
            return CreatorError.NotFound;
        }

        var tagsList = newArtwork.Tags
            .Select(tag => tag.TagName);

        if (tagsList is not null)
        {
            var selectedTags = _dbContext.Tags
                .Where(t => tagsList.Contains(t.TagName)).ToList();

            newArtwork.Tags = selectedTags;
        }

        newArtwork.Creator = creator;

        await _dbContext.AddAsync(newArtwork);
        await _dbContext.SaveChangesAsync();

        return newArtwork;
    }

    public async Task<ErrorOr<Deleted>> DeleteArtwork(Guid id)
    {
        var artwork = await _dbContext.Artworks
            .Include(a => a.Images)
            .SingleOrDefaultAsync(a => a.IdArtwork == id);

        if (artwork is null)
        {
            return ArtworkError.NotFound;
        }

        var images = artwork.Images.ToList();

        foreach (var image in images)
        {
            await _imageUploader.DeleteImage(image.CloudId);
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
            .Include(a => a.Creator)
            .Include(a => a.Tags)
            .Include(a => a.Images)
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
