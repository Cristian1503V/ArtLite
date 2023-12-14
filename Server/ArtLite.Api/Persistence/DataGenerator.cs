using ArtLite.Api.Entities;
using Bogus;

namespace ArtLite.Api.Persistence;

public class DataGenerator
{
    private readonly Faker<Artwork> artworkModelFake;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(123456);

        artworkModelFake = new Faker<Artwork>()
            .RuleFor(a => a.Title, f => f.Lorem.Sentence())
            .RuleFor(a => a.Description, f => f.Lorem.Paragraph())
            .RuleFor(a => a.CreatedAt, f => f.Date.Past())
        ;
    }


    public Artwork GenerateArtwork()
    {
        return artworkModelFake.Generate();
    }
}
