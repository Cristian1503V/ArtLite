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
            .HasIndex(c => c.Username)
            .IsUnique();

       modelBuilder.Entity<Creator>()
            .HasIndex(c => c.Slug)
            .IsUnique();

       modelBuilder.Entity<Tag>()
            .HasIndex(c => c.TagName)
            .IsUnique();

        modelBuilder.Entity<Image>()
        .HasIndex(i => new { i.Order, i.ArtworkId })
        .IsUnique();

        modelBuilder.Entity<Creator>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Creator>()
            .Property(c => c.UpdatedAt)
            .HasComputedColumnSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

        modelBuilder.Entity<Artwork>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Artwork>()
            .Property(c => c.UpdatedAt)
            .HasComputedColumnSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

        modelBuilder.Entity<Image>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");


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
            SocialInstagram = "https://www.instagram.com/sebacavazzoli.art",
            SocialYoutube = "https://www.youtube.com/sebastiancavazzoli",
            SocialFacebook = "",
            SocialLinkedin = "",
            SocialFigma = "",
            ProfileImage = "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898",
            ProfileBanner = "https://cdna.artstation.com/p/users/covers/000/583/624/default/73c0b86e24cfe09e6954896a1b24b5c0.jpg?1687826140"
        });

        List<Artwork> artworksList = new()
        {
            new() {
                Title = "3D Character",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/485/20231212212844/smaller_square/sebastian-cavazzoli-2313313.jpg?1702438125" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/365/large/sebastian-cavazzoli-yishu.jpg?1702437714" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/407/large/sebastian-cavazzoli-pp.jpg?1702437814" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/349/large/sebastian-cavazzoli-19.jpg?1702437673" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/070/397/400/large/sebastian-cavazzoli-2.jpg?1702437799" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/070/397/586/large/sebastian-cavazzoli-refe.jpg?1702438347" }
                }
            },
            new()
            {
                Title = "Pirate",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/064/384/223/smaller_square/sebastian-cavazzoli-1.jpg?1687806929" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/064/384/238/large/sebastian-cavazzoli-new-project.jpg?1687806957" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/064/384/233/large/sebastian-cavazzoli-2.jpg?1687806944" }
                }
            },
            new()
            {
                Title = "Tribal Mage",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/video_clips/images/066/131/241/smaller_square/sebastian-cavazzoli-thumb.jpg?1692121620" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/066/131/231/large/sebastian-cavazzoli-asset.jpg?1692121609" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/066/131/236/large/sebastian-cavazzoli-asset.jpg?1692121615" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/066/131/243/large/sebastian-cavazzoli-asset.jpg?1692121624" },
                }
            },
            new()
            {
                Title = "Joel - Pedro Pascal",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/062/527/639/smaller_square/sebastian-cavazzoli-04a4ddc0-1c5c-42a3-b4ff-5e8c77014ad4.jpg?1683333990" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/062/527/640/large/sebastian-cavazzoli-e3254524-8134-45f8-a5d7-12f489f95e4b.jpg?1683333994" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/062/527/642/large/sebastian-cavazzoli-f9ed5505-2e92-4e7c-af18-d1d770e747b6.jpg?1683333998" }
                }
            },
            new()
            {
                Title = "Goblin",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/058/444/123/smaller_square/sebastian-cavazzoli-1b.jpg?1674161052" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/058/444/135/large/sebastian-cavazzoli-2b.jpg?1674161070" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/058/444/254/large/sebastian-cavazzoli-asd.jpg?1674161336" }
                }
            },
            new()
            {
                Title = "Orc Lady",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/055/727/009/smaller_square/sebastian-cavazzoli-1.jpg?1667597373" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/055/726/896/large/sebastian-cavazzoli-2.jpg?1667597123" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/055/726/901/large/sebastian-cavazzoli-refe.jpg?1667597131" }
                }
            },
            new()
            {
                Title = "Lemmy",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/covers/images/052/375/327/20220807090628/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-cheloportada2.jpg?1659881189" }
                }
            },
            new()
            {
                Title = "WoW Gnome Warrior",
                Images = new List<Image>
                {
                    new() { Src = "https://cdna.artstation.com/p/assets/video_clips/images/045/020/050/smaller_square/sebastian-cavazzoli-thumb.jpg?1641742817" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/045/020/000/large/sebastian-cavazzoli-1-4.jpg?1641742734" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/045/019/996/large/sebastian-cavazzoli-3b-3.jpg?1641742715" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/045/019/990/large/sebastian-cavazzoli-4-6.jpg?1641742699" }
                }
            },
            new()
            {
                Title = "Knight fanart from Priston",
                Images = new List<Image>
                {
                    new() { Src = "https://cdna.artstation.com/p/assets/covers/images/037/967/798/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-3.jpg?1621816194" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/037/967/575/large/sebastian-cavazzoli-1b.jpg?1621815282" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/037/967/578/large/sebastian-cavazzoli-3.jpg?1621815288" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/037/967/552/large/sebastian-cavazzoli-4.jpg?1621815193" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/037/967/556/large/sebastian-cavazzoli-6.jpg?1621815211" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/037/967/559/large/sebastian-cavazzoli-7.jpg?1621815223" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/037/967/571/large/sebastian-cavazzoli-b2b.jpg?1621815273" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/037/967/569/large/sebastian-cavazzoli-b1.jpg?1621815262" }
                }
            },
            new()
            {
                Title = "Fighter from Priston Tale",
                Images = new List<Image>
                {
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/036/831/246/20210418093453/smaller_square/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/036/831/246/large/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/035/765/826/large/sebastian-cavazzoli-0.jpg?1615841303" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/035/766/297/large/sebastian-cavazzoli-5.jpg?1615842190" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/035/765/867/large/sebastian-cavazzoli-3b.jpg?1615841338" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/035/765/851/large/sebastian-cavazzoli-2.jpg?1615841326" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/035/765/840/large/sebastian-cavazzoli-1b.jpg?1615841315" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/035/765/882/large/sebastian-cavazzoli-back.jpg?1615841349" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/035/426/297/large/sebastian-cavazzoli-1.jpg?1614916297" }
                }
            },
            new()
            {
                Title = "Pike Man",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/143/017/smaller_square/sebastian-cavazzoli-7.jpg?1622294979" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/142/989/large/sebastian-cavazzoli-2.jpg?1622294909" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/142/995/large/sebastian-cavazzoli-3.jpg?1622294923" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/142/999/large/sebastian-cavazzoli-4.jpg?1622294937" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/154/939/large/sebastian-cavazzoli-a.jpg?1622324011" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/143/019/large/sebastian-cavazzoli-9.jpg?1622294992" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/038/143/029/large/sebastian-cavazzoli-wide2.jpg?1622295012" }
                }
            },
            new()
            {
                Title = "Mechanician",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/631/smaller_square/sebastian-cavazzoli-close2.jpg?1702438582" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/070/397/762/large/sebastian-cavazzoli-clay1.jpg?1702439021" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/070/397/767/large/sebastian-cavazzoli-clay2.jpg?1702439029" }
                }
            },
            new()
            {
                Title = "Atalanta",
                Images = new List<Image>
                {
                    new() { Src = "https://cdna.artstation.com/p/assets/covers/images/041/445/024/20210915103933/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-2cc.jpg?1631720373" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/041/444/824/large/sebastian-cavazzoli-2cc.jpg?1631719969" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/444/801/large/sebastian-cavazzoli-1a.jpg?1631719947" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/444/927/large/sebastian-cavazzoli-2b.jpg?1631720155" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/425/153/large/sebastian-cavazzoli-3b.jpg?1631660232" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/444/995/large/sebastian-cavazzoli-1aa.jpg?1631720258" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/424/055/large/sebastian-cavazzoli-1e.jpg?1631656468" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/041/425/085/large/sebastian-cavazzoli-5.jpg?1631659895" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/041/444/934/large/sebastian-cavazzoli-bb.jpg?1631720169" }
                }
            },
            new()
            {
                Title = "Goblins",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/covers/images/036/813/465/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-1.jpg?1618687643" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/036/813/236/large/sebastian-cavazzoli-2.jpg?1618687003" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/036/813/225/large/sebastian-cavazzoli-concept.jpg?1618686986" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/036/813/263/large/sebastian-cavazzoli-concept.jpg?1618687067" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/036/813/269/large/sebastian-cavazzoli-1.jpg?1618687081" },
                    new() { Src = "https://cdna.artstation.com/p/assets/images/images/036/813/276/large/sebastian-cavazzoli-2.jpg?1618687091" }
                }
            },
            new()
            {
                Title = "Stylized Cyclops",
                Images = new List<Image>
                {
                    new() { Src = "https://cdnb.artstation.com/p/assets/covers/images/034/485/459/20210203223805/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-01.jpg?1612413485" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/034/483/381/large/sebastian-cavazzoli-01.jpg?1612404174" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/034/483/403/large/sebastian-cavazzoli-05.jpg?1612404233" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/034/483/385/large/sebastian-cavazzoli-02.jpg?1612404193" },
                    new() { Src = "https://cdnb.artstation.com/p/assets/images/images/034/483/389/large/sebastian-cavazzoli-03.jpg?1612404201" }
                }
            }
        };

        var artworksGenerated = Enumerable.Range(1, artworksList.Count).Select(_ => _dataGenerator.GenerateArtwork()).ToList();
        List<Guid> artworksGuids = Enumerable.Range(0, artworksGenerated.Count).Select(_ => Guid.NewGuid()).ToList();
        modelBuilder.Entity<Artwork>().HasData(artworksGenerated.Select((artwork, index) =>
            new Artwork
            {
                IdArtwork = artworksGuids[index],
                Title = artworksList[index].Title,
                Description = artwork.Description,
                CreatedAt = artwork.CreatedAt,
                CreatorId = idCreator,
            }
        ).ToList());


        int totalImageCount = artworksList.SelectMany(a => a.Images).Count();
        modelBuilder.Entity<Image>().HasData(
            artworksList.SelectMany((artwork, artworkIndex) =>
                artwork.Images.Select((image, imageIndex) =>
                    new Image
                    {
                        IdImage = Guid.NewGuid(),
                        CloudId = "",
                        Src = image.Src,
                        Order = imageIndex + 1,
                        ArtworkId = artworksGuids[artworkIndex],
                    }
                )
            ).ToList()
        );


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
