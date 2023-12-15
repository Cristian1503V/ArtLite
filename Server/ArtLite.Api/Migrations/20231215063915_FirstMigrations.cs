using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtLite.Api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    IdCreator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HighlightedPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialFacebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialLinkedin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialFigma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileBanner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.IdCreator);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    IdTag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.IdTag);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    IdArtwork = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.IdArtwork);
                    table.ForeignKey(
                        name: "FK_Artworks_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "IdCreator");
                });

            migrationBuilder.CreateTable(
                name: "ArtworkTag",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkTag", x => new { x.TagId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_ArtworkTag_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "IdArtwork",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtworkTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "IdTag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    IdImage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloudId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.IdImage);
                    table.ForeignKey(
                        name: "FK_Images_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "IdArtwork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "IdCreator", "Biography", "Email", "HighlightedPhrase", "ProfileBanner", "ProfileImage", "Slug", "SocialFacebook", "SocialFigma", "SocialInstagram", "SocialLinkedin", "SocialYoutube", "Username" },
                values: new object[] { new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "3D Character Artist. I have a passion for 3D art. Currently working on my own personal projects!", "sebas@gmail.com", "3D Character Artist", "https://cdna.artstation.com/p/users/covers/000/583/624/default/73c0b86e24cfe09e6954896a1b24b5c0.jpg?1687826140", "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898", "sebastian_cavazzoli", "", "", "https://www.instagram.com/sebacavazzoli.art", "", "https://www.youtube.com/sebastiancavazzoli", "Sebastian Cavazzoli" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "IdTag", "TagName" },
                values: new object[,]
                {
                    { new Guid("02e52d9d-fa79-46dc-9485-4ddb714d47e4"), "Nature" },
                    { new Guid("0839b3dc-e20e-40dc-9fe1-c6525d54f461"), "Digital 2D" },
                    { new Guid("13550df2-3fe0-48ba-a978-e76fed9446d3"), "Animation" },
                    { new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad"), "Portrait" },
                    { new Guid("1d9ca9a0-09ef-4c8f-9b6f-08dc2823b535"), "Sci-Fi" },
                    { new Guid("24595347-6c76-43b3-97f7-9fe2a6da2a1f"), "Concept Art" },
                    { new Guid("33156ba9-d1eb-4550-83d3-e0646724620a"), "Pixel Art" },
                    { new Guid("3ba3eba1-770b-4ad4-b159-98fc4fd9c650"), "Street Art" },
                    { new Guid("479136d1-6434-4d4a-af2c-e5bcd2cf97e8"), "Surrealism" },
                    { new Guid("4b2e33cc-a082-48bc-be42-3e12de8592b1"), "Minimalism" },
                    { new Guid("5b3ddd89-1a19-43a8-8db6-12c354b49c83"), "Urban Art" },
                    { new Guid("5b9379ba-5aee-4929-b0bd-b3b7ca0b27e0"), "Character Design" },
                    { new Guid("5f6f013c-4e9e-432e-8cb3-e986af591aeb"), "Graffiti" },
                    { new Guid("616467f5-b3bb-4bbd-aaf9-04203410cf2b"), "Abstract" },
                    { new Guid("861a2ed1-a9a1-420b-8607-a312cfc8a494"), "Cubism" },
                    { new Guid("8ba9a6e8-84be-4ef0-acfc-b22d8a73b963"), "Storytelling" },
                    { new Guid("95150a51-6a05-48ac-a394-036436ef7f51"), "Comics" },
                    { new Guid("a0cd7970-46fe-4399-8029-67913788fb60"), "Calligraphy" },
                    { new Guid("a87b31a6-059c-4271-84dd-784c5b8e4f47"), "Watercolor" },
                    { new Guid("b50b6375-ecf3-4c86-97a4-9eeb1750d3c1"), "Fantasy" },
                    { new Guid("c29f0adf-f3d1-4baf-b21d-8f50db2611a6"), "Photorealism" },
                    { new Guid("c5fb02bd-bf50-4463-b682-a220feb3e6fe"), "Abstract Expressionism" },
                    { new Guid("cf0e2e7b-b321-4788-9c62-288cf1d643b6"), "Impressionism" },
                    { new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd"), "Typography" },
                    { new Guid("ef0aed54-124e-47f8-91a6-dec8cb654e1a"), "Digital Painting" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "IdArtwork", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), new DateTime(2023, 5, 10, 12, 58, 18, 857, DateTimeKind.Local).AddTicks(9998), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Culpa inventore omnis ipsam mollitia sed incidunt praesentium. Et commodi ad dignissimos id. Aut assumenda quam dolor quos officia quaerat. In dolorum necessitatibus at repellat libero sunt sint tempora.", "Mechanician" },
                    { new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), new DateTime(2023, 8, 2, 23, 46, 6, 136, DateTimeKind.Local).AddTicks(7502), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Possimus facilis quia sed ipsum officiis qui qui molestias. Doloremque ea id voluptates facere fugiat fugiat. Rerum atque quibusdam. Non fugiat voluptatem qui nisi sunt. Qui rerum rerum praesentium molestiae hic iure. Ea quia et iste excepturi nesciunt.", "Pirate" },
                    { new Guid("24234d88-d57a-4a89-af74-999672025fc1"), new DateTime(2023, 10, 24, 9, 2, 25, 827, DateTimeKind.Local).AddTicks(2588), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Aut fugiat aut sint porro. Sunt laborum distinctio quo voluptatem eveniet sunt tempora et ut. Voluptas aspernatur occaecati sapiente. Eum voluptatem quo velit sed officia et. Deserunt nemo illo rerum illum necessitatibus sit eius sapiente ducimus.", "Goblins" },
                    { new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), new DateTime(2023, 1, 2, 5, 7, 16, 199, DateTimeKind.Local).AddTicks(2746), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Deserunt quos adipisci rem voluptatibus sit exercitationem consequatur. Mollitia maiores omnis quasi voluptatem hic earum nisi facilis autem. Eius dolor doloremque qui eveniet nulla et dicta. Impedit est et sequi accusantium est nam aut. Sit nulla sed dolor iste.", "Knight fanart from Priston" },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new DateTime(2023, 5, 29, 7, 19, 57, 919, DateTimeKind.Local).AddTicks(2814), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Odit ratione aut. Magni ea quisquam culpa magni vitae officiis id maiores vel. Deleniti voluptate nobis. Veniam sequi dolorem et neque quia esse sit perspiciatis.", "WoW Gnome Warrior" },
                    { new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), new DateTime(2023, 5, 24, 10, 36, 13, 738, DateTimeKind.Local).AddTicks(1783), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Culpa consequatur perferendis cupiditate non ipsam sint corrupti incidunt. Optio quod quo enim aut aut voluptatem ullam. Optio nihil soluta ut. Est maiores eos cum iure quo nobis fugit ea.", "Atalanta" },
                    { new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), new DateTime(2023, 12, 4, 11, 9, 40, 350, DateTimeKind.Local).AddTicks(9315), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Doloremque qui quam modi rem quibusdam vel ratione beatae. Velit architecto natus est quos. Nostrum sed veritatis vitae temporibus aliquam esse qui est. Laboriosam vitae facilis porro. Facere rem ut quidem est blanditiis fugit ipsa rem dolorem.", "Pike Man" },
                    { new Guid("6d4facd0-299c-4d96-835e-b3fad8986c5a"), new DateTime(2023, 11, 13, 20, 6, 0, 997, DateTimeKind.Local).AddTicks(2065), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Harum sed ut aliquid. Mollitia tempora quos ex perferendis et optio similique et fuga. Est vero molestiae. Eos provident rerum. Nam eos ipsam quasi. Omnis at et veniam eum.", "Lemmy" },
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new DateTime(2023, 10, 20, 16, 9, 58, 488, DateTimeKind.Local).AddTicks(9475), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Iusto quia inventore voluptas expedita laborum eum omnis occaecati. Qui nihil aperiam assumenda eveniet autem. Vel sit libero rerum animi.", "3D Character" },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new DateTime(2023, 12, 14, 0, 19, 7, 246, DateTimeKind.Local).AddTicks(2812), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Rem eveniet est officia voluptas eum omnis illum expedita est. Eum nam eos nihil. Autem dolorem optio accusantium nemo consectetur enim dolores. Cumque libero culpa rerum voluptas.", "Goblin" },
                    { new Guid("bb6aace8-b87f-4789-9f87-9f61da57ae72"), new DateTime(2022, 12, 25, 1, 11, 5, 137, DateTimeKind.Local).AddTicks(7946), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Ut dolorem illo laudantium. Sit sit praesentium aperiam praesentium ut quos. Nam ad in. Qui incidunt ut fuga porro. Non vel quisquam ut. Animi et qui non eum.", "Orc Lady" },
                    { new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), new DateTime(2023, 2, 25, 0, 38, 38, 303, DateTimeKind.Local).AddTicks(5092), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Esse praesentium quibusdam sunt dolores quo non. Ad hic maxime fuga quae suscipit. Delectus perferendis praesentium hic mollitia. Dolorum vitae est. Rerum sint dolores vel libero blanditiis. Suscipit excepturi enim sed dolor possimus quae magni voluptates.", "Fighter from Priston Tale" },
                    { new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), new DateTime(2023, 7, 31, 5, 39, 19, 805, DateTimeKind.Local).AddTicks(4921), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Ut non eligendi. Voluptatem ullam odit. Reprehenderit qui et sed sint ea. Perspiciatis quisquam sed nulla voluptas est voluptate repudiandae ea a. Et autem necessitatibus quia id quod perferendis sunt consectetur expedita.", "Stylized Cyclops" },
                    { new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), new DateTime(2023, 1, 26, 11, 54, 20, 489, DateTimeKind.Local).AddTicks(2317), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Quisquam veritatis sequi tempora et quod dolor. Quibusdam harum laborum. Molestiae necessitatibus nisi est molestiae. Sit enim et asperiores voluptatum dolorem voluptas laudantium. Quia minima et et hic aut et sed omnis occaecati. Animi officiis sed corporis dolores nesciunt quia quia.", "Joel - Pedro Pascal" },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new DateTime(2023, 3, 1, 9, 48, 41, 270, DateTimeKind.Local).AddTicks(4084), new Guid("d53570c7-8651-4fc6-9cce-15848be6f289"), "Consequatur sit quo quos sint officia. Dolore eius consequatur harum ratione earum consequatur. Commodi iure voluptatum et quia molestiae quis ut natus voluptatem. Pariatur facere et nihil id. Saepe sit et. Tempore a nulla et eveniet enim exercitationem.", "Tribal Mage" }
                });

            migrationBuilder.InsertData(
                table: "ArtworkTag",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new Guid("13550df2-3fe0-48ba-a978-e76fed9446d3") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad") },
                    { new Guid("6d4facd0-299c-4d96-835e-b3fad8986c5a"), new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad") },
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad") },
                    { new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad") },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new Guid("1661b07d-ca10-4cae-9cf0-62d98e226bad") },
                    { new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), new Guid("24595347-6c76-43b3-97f7-9fe2a6da2a1f") },
                    { new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), new Guid("24595347-6c76-43b3-97f7-9fe2a6da2a1f") },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new Guid("33156ba9-d1eb-4550-83d3-e0646724620a") },
                    { new Guid("24234d88-d57a-4a89-af74-999672025fc1"), new Guid("3ba3eba1-770b-4ad4-b159-98fc4fd9c650") },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new Guid("3ba3eba1-770b-4ad4-b159-98fc4fd9c650") },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new Guid("479136d1-6434-4d4a-af2c-e5bcd2cf97e8") },
                    { new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), new Guid("4b2e33cc-a082-48bc-be42-3e12de8592b1") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("5b3ddd89-1a19-43a8-8db6-12c354b49c83") },
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new Guid("5b3ddd89-1a19-43a8-8db6-12c354b49c83") },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new Guid("5b3ddd89-1a19-43a8-8db6-12c354b49c83") },
                    { new Guid("6d4facd0-299c-4d96-835e-b3fad8986c5a"), new Guid("5b9379ba-5aee-4929-b0bd-b3b7ca0b27e0") },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new Guid("5b9379ba-5aee-4929-b0bd-b3b7ca0b27e0") },
                    { new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), new Guid("5f6f013c-4e9e-432e-8cb3-e986af591aeb") },
                    { new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), new Guid("616467f5-b3bb-4bbd-aaf9-04203410cf2b") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("616467f5-b3bb-4bbd-aaf9-04203410cf2b") },
                    { new Guid("bb6aace8-b87f-4789-9f87-9f61da57ae72"), new Guid("8ba9a6e8-84be-4ef0-acfc-b22d8a73b963") },
                    { new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), new Guid("95150a51-6a05-48ac-a394-036436ef7f51") },
                    { new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), new Guid("95150a51-6a05-48ac-a394-036436ef7f51") },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new Guid("95150a51-6a05-48ac-a394-036436ef7f51") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("a0cd7970-46fe-4399-8029-67913788fb60") },
                    { new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), new Guid("a87b31a6-059c-4271-84dd-784c5b8e4f47") },
                    { new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), new Guid("b50b6375-ecf3-4c86-97a4-9eeb1750d3c1") },
                    { new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), new Guid("b50b6375-ecf3-4c86-97a4-9eeb1750d3c1") },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new Guid("b50b6375-ecf3-4c86-97a4-9eeb1750d3c1") },
                    { new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), new Guid("c29f0adf-f3d1-4baf-b21d-8f50db2611a6") },
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new Guid("c5fb02bd-bf50-4463-b682-a220feb3e6fe") },
                    { new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), new Guid("cf0e2e7b-b321-4788-9c62-288cf1d643b6") },
                    { new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd") },
                    { new Guid("7443d740-b827-47dd-9d92-0dff40042228"), new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd") },
                    { new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd") },
                    { new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), new Guid("eb72089e-33fa-42d8-80fb-43be40f4f6fd") },
                    { new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), new Guid("ef0aed54-124e-47f8-91a6-dec8cb654e1a") },
                    { new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), new Guid("ef0aed54-124e-47f8-91a6-dec8cb654e1a") },
                    { new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), new Guid("ef0aed54-124e-47f8-91a6-dec8cb654e1a") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "IdImage", "ArtworkId", "CloudId", "Order", "Src" },
                values: new object[,]
                {
                    { new Guid("00a0d4d7-9d86-47c7-a54a-ffa5b82bd515"), new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/070/397/767/large/sebastian-cavazzoli-clay2.jpg?1702439029" },
                    { new Guid("0f289f84-becb-4f28-9f5e-573ccbe1e601"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 1, "https://cdna.artstation.com/p/assets/covers/images/037/967/798/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-3.jpg?1621816194" },
                    { new Guid("152d78d8-134b-40ed-9c3a-ef4ca990dc1b"), new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/034/483/403/large/sebastian-cavazzoli-05.jpg?1612404233" },
                    { new Guid("15fff774-816b-436f-81f5-d863bbf11fdb"), new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/058/444/123/smaller_square/sebastian-cavazzoli-1b.jpg?1674161052" },
                    { new Guid("161d0c07-45dd-480a-97d8-c1c9246003df"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 6, "https://cdnb.artstation.com/p/assets/images/images/035/765/851/large/sebastian-cavazzoli-2.jpg?1615841326" },
                    { new Guid("16fe6b23-d7ae-44d5-a783-3bbd12750c46"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 2, "https://cdna.artstation.com/p/assets/images/images/036/813/236/large/sebastian-cavazzoli-2.jpg?1618687003" },
                    { new Guid("1a844055-ff4f-441c-ae38-e9786aeccfc1"), new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/066/131/231/large/sebastian-cavazzoli-asset.jpg?1692121609" },
                    { new Guid("1b28b012-2cf5-4526-be03-34b09774633d"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 7, "https://cdnb.artstation.com/p/assets/images/images/037/967/571/large/sebastian-cavazzoli-b2b.jpg?1621815273" },
                    { new Guid("21430ea5-79a8-48d3-a68d-8ae4b619f437"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/070/397/407/large/sebastian-cavazzoli-pp.jpg?1702437814" },
                    { new Guid("24a6844a-2581-49e5-9a15-2d7ba7099566"), new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), "", 3, "https://cdna.artstation.com/p/assets/images/images/062/527/642/large/sebastian-cavazzoli-f9ed5505-2e92-4e7c-af18-d1d770e747b6.jpg?1683333998" },
                    { new Guid("2aca330c-16f8-4b12-bc80-165ef0b617b3"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 5, "https://cdna.artstation.com/p/assets/images/images/070/397/400/large/sebastian-cavazzoli-2.jpg?1702437799" },
                    { new Guid("2c9f9c77-6127-4c52-9096-c253b8f3a4fc"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 5, "https://cdnb.artstation.com/p/assets/images/images/041/425/153/large/sebastian-cavazzoli-3b.jpg?1631660232" },
                    { new Guid("2cac06a9-08ec-487b-98c7-a10eeef10250"), new Guid("6d4facd0-299c-4d96-835e-b3fad8986c5a"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/052/375/327/20220807090628/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-cheloportada2.jpg?1659881189" },
                    { new Guid("2fabb156-fe75-4908-baf4-59fdf2e08dbb"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/070/397/485/20231212212844/smaller_square/sebastian-cavazzoli-2313313.jpg?1702438125" },
                    { new Guid("30841827-fcec-4107-a506-f6a76833c28e"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 6, "https://cdna.artstation.com/p/assets/images/images/036/813/276/large/sebastian-cavazzoli-2.jpg?1618687091" },
                    { new Guid("35301d7d-06f3-4caa-b1b8-591fa911a215"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 1, "https://cdna.artstation.com/p/assets/covers/images/041/445/024/20210915103933/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-2cc.jpg?1631720373" },
                    { new Guid("3760d0ec-1d32-4eeb-9f94-0425edaca600"), new Guid("bb6aace8-b87f-4789-9f87-9f61da57ae72"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/055/727/009/smaller_square/sebastian-cavazzoli-1.jpg?1667597373" },
                    { new Guid("41f40471-c64f-42ad-9601-9abcba031961"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/035/766/297/large/sebastian-cavazzoli-5.jpg?1615842190" },
                    { new Guid("41fd76e3-ea0b-4c96-8d9c-8c825c103ce2"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 1, "https://cdna.artstation.com/p/assets/images/images/036/831/246/20210418093453/smaller_square/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
                    { new Guid("43c01fe3-6638-446d-b0bc-3c093ab65ff8"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/038/142/999/large/sebastian-cavazzoli-4.jpg?1622294937" },
                    { new Guid("442886e3-dff9-49f7-bc3c-63b4649b0b13"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 5, "https://cdnb.artstation.com/p/assets/images/images/035/765/867/large/sebastian-cavazzoli-3b.jpg?1615841338" },
                    { new Guid("44807e0b-28b7-460f-aa22-1fd9bccf6138"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/041/444/801/large/sebastian-cavazzoli-1a.jpg?1631719947" },
                    { new Guid("44fd6cbe-757e-4687-90b0-406556fd6141"), new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/034/485/459/20210203223805/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-01.jpg?1612413485" },
                    { new Guid("464c98da-8f53-43a4-ad15-74878a226beb"), new Guid("bb6aace8-b87f-4789-9f87-9f61da57ae72"), "", 2, "https://cdna.artstation.com/p/assets/images/images/055/726/896/large/sebastian-cavazzoli-2.jpg?1667597123" },
                    { new Guid("46a3b6ae-65b1-4ff0-8ef6-bc96b27f256a"), new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/070/397/631/smaller_square/sebastian-cavazzoli-close2.jpg?1702438582" },
                    { new Guid("50820e84-cfb8-4f22-9a3a-28912b1d10f9"), new Guid("bb6aace8-b87f-4789-9f87-9f61da57ae72"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/055/726/901/large/sebastian-cavazzoli-refe.jpg?1667597131" },
                    { new Guid("56ba2ceb-9600-4949-a366-43ef4ca8d9f6"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/036/813/465/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-1.jpg?1618687643" },
                    { new Guid("58fddfa8-3fbc-40d2-bf76-e7c4467ecdd7"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/036/813/263/large/sebastian-cavazzoli-concept.jpg?1618687067" },
                    { new Guid("5bbba578-9a85-45d6-acf2-c336ab152287"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/070/397/349/large/sebastian-cavazzoli-19.jpg?1702437673" },
                    { new Guid("5e54116b-5189-44f0-874b-9dee8542bc9d"), new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), "", 3, "https://cdna.artstation.com/p/assets/images/images/066/131/236/large/sebastian-cavazzoli-asset.jpg?1692121615" },
                    { new Guid("5f540320-1ddc-4302-9c29-948fd0291667"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/038/143/017/smaller_square/sebastian-cavazzoli-7.jpg?1622294979" },
                    { new Guid("62765a44-f0dd-4c1c-b53e-81c3c0b186d2"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 8, "https://cdnb.artstation.com/p/assets/images/images/037/967/569/large/sebastian-cavazzoli-b1.jpg?1621815262" },
                    { new Guid("65890ea8-dd41-448c-a540-c6f7e7d7eac9"), new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/064/384/223/smaller_square/sebastian-cavazzoli-1.jpg?1687806929" },
                    { new Guid("66e5ad65-7831-4601-ba97-d439550382ba"), new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/062/527/639/smaller_square/sebastian-cavazzoli-04a4ddc0-1c5c-42a3-b4ff-5e8c77014ad4.jpg?1683333990" },
                    { new Guid("78f20fe9-10bf-4ec5-a778-732916542fa7"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/038/142/989/large/sebastian-cavazzoli-2.jpg?1622294909" },
                    { new Guid("7b9ecd46-5894-4c1b-ba3a-fc56c9d60a88"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 2, "https://cdna.artstation.com/p/assets/images/images/036/831/246/large/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
                    { new Guid("7da95963-27b5-4b31-bef8-d038a503d2c6"), new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/064/384/233/large/sebastian-cavazzoli-2.jpg?1687806944" },
                    { new Guid("7f11f1cd-a506-4866-bb9e-078a9229a21b"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 9, "https://cdna.artstation.com/p/assets/images/images/041/444/934/large/sebastian-cavazzoli-bb.jpg?1631720169" },
                    { new Guid("7fdce895-c16b-4de9-b0ae-76355da86874"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 6, "https://cdnb.artstation.com/p/assets/images/images/037/967/559/large/sebastian-cavazzoli-7.jpg?1621815223" },
                    { new Guid("82d84326-df69-45a6-8118-2a3e98a94596"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 6, "https://cdnb.artstation.com/p/assets/images/images/038/143/019/large/sebastian-cavazzoli-9.jpg?1622294992" },
                    { new Guid("88e1c6de-213b-4273-b82a-1acff0c0e8e3"), new Guid("1cd4cc4a-4a4a-4eb8-92b7-036a4e3d5520"), "", 2, "https://cdna.artstation.com/p/assets/images/images/064/384/238/large/sebastian-cavazzoli-new-project.jpg?1687806957" },
                    { new Guid("8e34ee02-737d-4244-a70e-d5bb95dfcd44"), new Guid("ca8d3891-f868-4da0-8774-29b259eb5c8f"), "", 2, "https://cdna.artstation.com/p/assets/images/images/062/527/640/large/sebastian-cavazzoli-e3254524-8134-45f8-a5d7-12f489f95e4b.jpg?1683333994" },
                    { new Guid("8edb9817-a17c-44f6-a3f0-20fabd49eb03"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 5, "https://cdnb.artstation.com/p/assets/images/images/038/154/939/large/sebastian-cavazzoli-a.jpg?1622324011" },
                    { new Guid("8f94c39a-2db4-4691-baa1-c7e522fb91ac"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 7, "https://cdnb.artstation.com/p/assets/images/images/038/143/029/large/sebastian-cavazzoli-wide2.jpg?1622295012" },
                    { new Guid("9af2563d-9916-488a-a4ea-0fd4755f7550"), new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/034/483/385/large/sebastian-cavazzoli-02.jpg?1612404193" },
                    { new Guid("9dd37231-29bb-47ad-a544-fb5ee1b48e91"), new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/066/131/243/large/sebastian-cavazzoli-asset.jpg?1692121624" },
                    { new Guid("a03c1514-62c3-450e-9959-1f4c89bde650"), new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), "", 4, "https://cdna.artstation.com/p/assets/images/images/045/019/990/large/sebastian-cavazzoli-4-6.jpg?1641742699" },
                    { new Guid("a2e1dc6c-fbfe-4975-98e4-f13774448a02"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 4, "https://cdna.artstation.com/p/assets/images/images/037/967/552/large/sebastian-cavazzoli-4.jpg?1621815193" },
                    { new Guid("a7398954-1770-4780-9653-4ac07c82bd18"), new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/034/483/381/large/sebastian-cavazzoli-01.jpg?1612404174" },
                    { new Guid("a8949f0e-7e05-4c65-8e43-e477a3acb3d7"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 5, "https://cdna.artstation.com/p/assets/images/images/037/967/556/large/sebastian-cavazzoli-6.jpg?1621815211" },
                    { new Guid("acc06c97-c77e-480c-9975-af2b69ae0d0c"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 2, "https://cdna.artstation.com/p/assets/images/images/041/444/824/large/sebastian-cavazzoli-2cc.jpg?1631719969" },
                    { new Guid("addfbe23-6974-40ef-b14b-9e4bb3f64339"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 3, "https://cdna.artstation.com/p/assets/images/images/035/765/826/large/sebastian-cavazzoli-0.jpg?1615841303" },
                    { new Guid("af951a97-3b76-4fc6-9bc7-9a68a15dee7f"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 8, "https://cdna.artstation.com/p/assets/images/images/035/765/882/large/sebastian-cavazzoli-back.jpg?1615841349" },
                    { new Guid("b2c7375b-8b49-46e7-be9e-dcdb6bd11607"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/036/813/225/large/sebastian-cavazzoli-concept.jpg?1618686986" },
                    { new Guid("bba17a7d-4a5b-4ec6-b7ff-60c175e92e5a"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 6, "https://cdnb.artstation.com/p/assets/images/images/041/444/995/large/sebastian-cavazzoli-1aa.jpg?1631720258" },
                    { new Guid("bc18a641-f130-4e05-b159-9950439f863f"), new Guid("05e8dad6-4683-4e79-acdc-bceada8b55a6"), "", 2, "https://cdna.artstation.com/p/assets/images/images/070/397/762/large/sebastian-cavazzoli-clay1.jpg?1702439021" },
                    { new Guid("bd53d473-79b7-4f2a-ac53-e784179a678f"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 7, "https://cdnb.artstation.com/p/assets/images/images/041/424/055/large/sebastian-cavazzoli-1e.jpg?1631656468" },
                    { new Guid("bf660dd8-2182-422d-a50d-addbd1fccff9"), new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), "", 3, "https://cdna.artstation.com/p/assets/images/images/058/444/254/large/sebastian-cavazzoli-asd.jpg?1674161336" },
                    { new Guid("c424e740-d661-4e6a-ade6-ad8f0cdfed63"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 4, "https://cdnb.artstation.com/p/assets/images/images/041/444/927/large/sebastian-cavazzoli-2b.jpg?1631720155" },
                    { new Guid("c97c7945-a60d-411b-862f-0bb57ba76fb2"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/070/397/365/large/sebastian-cavazzoli-yishu.jpg?1702437714" },
                    { new Guid("d125ad1e-92c0-40f7-ab32-2d40caf34a29"), new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), "", 2, "https://cdna.artstation.com/p/assets/images/images/045/020/000/large/sebastian-cavazzoli-1-4.jpg?1641742734" },
                    { new Guid("d810d6a5-5b2f-4529-abca-5fac0f108471"), new Guid("932a65c4-ee3f-4b71-96ec-4b132b7c505e"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/058/444/135/large/sebastian-cavazzoli-2b.jpg?1674161070" },
                    { new Guid("df46542c-ca14-4f1e-8be6-a3a72c5101cc"), new Guid("5da4c9ae-86df-4632-8ffa-865d7a20b425"), "", 3, "https://cdnb.artstation.com/p/assets/images/images/038/142/995/large/sebastian-cavazzoli-3.jpg?1622294923" },
                    { new Guid("e0bfd700-662f-4242-ac0f-250d9b0eaaaa"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 7, "https://cdna.artstation.com/p/assets/images/images/035/765/840/large/sebastian-cavazzoli-1b.jpg?1615841315" },
                    { new Guid("e1520d82-80e3-4bb0-acd6-00485e344afa"), new Guid("24234d88-d57a-4a89-af74-999672025fc1"), "", 5, "https://cdnb.artstation.com/p/assets/images/images/036/813/269/large/sebastian-cavazzoli-1.jpg?1618687081" },
                    { new Guid("e21e1616-3d68-49ed-8299-c5068b051cd6"), new Guid("7443d740-b827-47dd-9d92-0dff40042228"), "", 6, "https://cdna.artstation.com/p/assets/images/images/070/397/586/large/sebastian-cavazzoli-refe.jpg?1702438347" },
                    { new Guid("e3093a5a-c324-4f19-a5b6-879e971a6853"), new Guid("edb8d3de-3a0e-4149-ad04-7b82c14eca57"), "", 1, "https://cdnb.artstation.com/p/assets/video_clips/images/066/131/241/smaller_square/sebastian-cavazzoli-thumb.jpg?1692121620" },
                    { new Guid("e693da76-a51a-4408-8fb6-55ae94776e80"), new Guid("c809a906-01f9-4eee-bd68-1a7e46e97b21"), "", 5, "https://cdnb.artstation.com/p/assets/images/images/034/483/389/large/sebastian-cavazzoli-03.jpg?1612404201" },
                    { new Guid("e8834e14-aec6-44f8-93c0-7edf44b497ea"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 2, "https://cdnb.artstation.com/p/assets/images/images/037/967/575/large/sebastian-cavazzoli-1b.jpg?1621815282" },
                    { new Guid("ea3e1123-c391-4e8d-8cb7-e8e54bad5155"), new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), "", 3, "https://cdna.artstation.com/p/assets/images/images/045/019/996/large/sebastian-cavazzoli-3b-3.jpg?1641742715" },
                    { new Guid("ead7fa71-6088-42d7-96ba-2ee34118b25e"), new Guid("55b6cc08-d79d-4485-81c6-07ed39c064e5"), "", 1, "https://cdna.artstation.com/p/assets/video_clips/images/045/020/050/smaller_square/sebastian-cavazzoli-thumb.jpg?1641742817" },
                    { new Guid("f30079cd-ab98-4f45-bd43-cad54b79f316"), new Guid("5d2961ef-985f-44e4-93f0-5a563bb4ef62"), "", 8, "https://cdnb.artstation.com/p/assets/images/images/041/425/085/large/sebastian-cavazzoli-5.jpg?1631659895" },
                    { new Guid("f375b523-f003-414a-8112-e5c1225c2e83"), new Guid("387ca2ab-87ef-4613-8039-58986ecb4e7c"), "", 3, "https://cdna.artstation.com/p/assets/images/images/037/967/578/large/sebastian-cavazzoli-3.jpg?1621815288" },
                    { new Guid("f91d62ce-1e88-4577-a059-df8e14a1095c"), new Guid("c25e263a-1ac6-4f26-867a-43deaa3f8f26"), "", 9, "https://cdnb.artstation.com/p/assets/images/images/035/426/297/large/sebastian-cavazzoli-1.jpg?1614916297" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_CreatorId",
                table: "Artworks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkTag_ArtworkId",
                table: "ArtworkTag",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_Email",
                table: "Creators",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creators_Slug",
                table: "Creators",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creators_Username",
                table: "Creators",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtworkId",
                table: "Images",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Order_ArtworkId",
                table: "Images",
                columns: new[] { "Order", "ArtworkId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagName",
                table: "Tags",
                column: "TagName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworkTag");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Creators");
        }
    }
}
