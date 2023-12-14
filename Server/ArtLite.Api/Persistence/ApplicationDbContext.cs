using ArtLite.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtLite.Api.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Creator> Creators { get; set; }

    private readonly DataGenerator _dataGenerator;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DataGenerator dataGenerator) : base(options)
    {
        _dataGenerator = dataGenerator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Creator>()
            .HasIndex(c => c.Email)
            .IsUnique();

       modelBuilder.Entity<Creator>()
            .HasIndex(c => c.Slug)
            .IsUnique();

        modelBuilder.Entity<Creator>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Creator>()
            .Property(c => c.UpdatedAt)
            .ValueGeneratedOnUpdate()
            .HasDefaultValueSql("GETUTCDATE()");


        modelBuilder.Entity<Artwork>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Artwork>()
            .Property(c => c.UpdatedAt)
            .ValueGeneratedOnUpdate()
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Image>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");


        modelBuilder.Entity<Artwork>()
            .HasOne(a => a.Creator)
            .WithMany(u => u.Artworks)
            .OnDelete(DeleteBehavior.NoAction);
        
        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }


    private void SeedData (ModelBuilder modelBuilder)
    {
        List<string> tagNames = new()
        {
            "Digital 2D", "Fantasy", "Concept Art", "Storytelling", "Character Design",
            "Sci-Fi", "Abstract", "Nature", "Portrait", "Typography",
            "Animation", "Minimalism", "Surrealism", "Comics", "Abstract Expressionism",
            "Photorealism", "Urban Art", "Graffiti", "Calligraphy", "Cubism",
            "Digital Painting", "Street Art", "Impressionism", "Watercolor", "Pixel Art"
        };
        List<Guid> tagGuids = Enumerable.Range(0, tagNames.Count).Select(_ => Guid.NewGuid()).ToList();

        modelBuilder.Entity<Tag>().HasData(tagNames.Select((tagName, index) =>
            new Tag { IdTag = tagGuids[index], TagName = tagName }
        ).ToList());


        var idCreator = Guid.NewGuid();


        modelBuilder.Entity<Creator>().HasData(new Creator {
            IdCreator = idCreator,
            Username = "Sebastian Cavazzoli",
            Slug = "sebastian_cavazzoli",
            Email = "sebas@gmail.com",
            HighlightedPhrase = "3D Character Artist",
            Biography = "3D Character Artist. I have a passion for 3D art. Currently working on my own personal projects!",
            SocialInstagram = "",
            SocialYoutube = "",
            SocialFacebook = "",
            SocialLinkedin = "",
            SocialFigma = "",
            ProfileImage = "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
        });


        List<Image> images = new()
        {
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/485/20231212212844/smaller_square/sebastian-cavazzoli-2313313.jpg?1702438125" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/064/384/223/smaller_square/sebastian-cavazzoli-1.jpg?1687806929" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/video_clips/images/066/131/241/smaller_square/sebastian-cavazzoli-thumb.jpg?1692121620" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/062/527/639/smaller_square/sebastian-cavazzoli-04a4ddc0-1c5c-42a3-b4ff-5e8c77014ad4.jpg?1683333990" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/058/444/123/smaller_square/sebastian-cavazzoli-1b.jpg?1674161052" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/055/727/009/smaller_square/sebastian-cavazzoli-1.jpg?1667597373" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/covers/images/052/375/327/20220807090628/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-cheloportada2.jpg?1659881189" },
            new Image { Src = "https://cdna.artstation.com/p/assets/video_clips/images/045/020/050/smaller_square/sebastian-cavazzoli-thumb.jpg?1641742817" },
            new Image { Src = "https://cdna.artstation.com/p/assets/covers/images/037/967/798/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-3.jpg?1621816194" },
            new Image { Src = "https://cdna.artstation.com/p/assets/images/images/036/831/246/20210418093453/smaller_square/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/038/143/017/smaller_square/sebastian-cavazzoli-7.jpg?1622294979" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/631/smaller_square/sebastian-cavazzoli-close2.jpg?1702438582" },
            new Image { Src = "https://cdna.artstation.com/p/assets/covers/images/041/445/024/20210915103933/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-2cc.jpg?1631720373" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/covers/images/036/813/465/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-1.jpg?1618687643" },
            new Image { Src = "https://cdnb.artstation.com/p/assets/covers/images/034/485/459/20210203223805/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-01.jpg?1612413485" }
        };

        var artworksGenerated = Enumerable.Range(1, images.Count).Select(_ => _dataGenerator.GenerateArtwork()).ToList();
        List<Guid> artworksGuids = Enumerable.Range(0, artworksGenerated.Count).Select(_ => Guid.NewGuid()).ToList();
        modelBuilder.Entity<Artwork>().HasData(artworksGenerated.Select((artwork, index) =>
            new Artwork
            {
                IdArtwork = artworksGuids[index],
                Title = artwork.Title,
                Description = artwork.Description,
                CreatedAt = artwork.CreatedAt,
                CreatorId = idCreator,
            }
        ).ToList());


        List<Guid> imagesGuids = Enumerable.Range(0, images.Count).Select(_ => Guid.NewGuid()).ToList();
        modelBuilder.Entity<Image>().HasData(images.Select((image, index) =>
            new Image
            {
                IdImage = imagesGuids[index],
                CloudId = "",
                Src = image.Src,
                Order = 1,
                ArtworkId = artworksGuids[index],
            }
        ).ToList());


        var random = new Random();
        var uniquePairsTags = new HashSet<(Guid TagId, Guid ArtworkId)>();

        var TagsData = artworksGenerated.SelectMany((artwork, index) =>
        {
            var pairs = Enumerable.Range(0, random.Next(1, 5)).Select(i =>
            {
                Guid tagId, artworkId;
                do
                {
                    tagId = tagGuids[random.Next(tagGuids.Count)];
                    artworkId = artworksGuids[random.Next(artworksGuids.Count)];
                } while (!uniquePairsTags.Add((tagId, artworkId)));

                return new { TagId = tagId, ArtworkId = artworkId };
            });

            return pairs;
        }).ToList();

        modelBuilder.Entity<Artwork>()
        .HasMany(e => e.Tags)
        .WithMany(e => e.Artworks)
        .UsingEntity(
            "ArtworkTag",
            l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId"),
            r => r.HasOne(typeof(Artwork)).WithMany().HasForeignKey("ArtworkId"),
            j => {
                j.HasKey("TagId", "ArtworkId");
                j.HasData(TagsData.Select(data => new { TagId = data.TagId, ArtworkId = data.ArtworkId }));
            });

    }

}
