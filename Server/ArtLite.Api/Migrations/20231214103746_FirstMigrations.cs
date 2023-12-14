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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
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
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
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
                values: new object[] { new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "3D Character Artist. I have a passion for 3D art. Currently working on my own personal projects!", "sebas@gmail.com", "3D Character Artist", "https://cdna.artstation.com/p/users/covers/000/583/624/default/73c0b86e24cfe09e6954896a1b24b5c0.jpg?1687826140", "https://cdna.artstation.com/p/users/avatars/000/583/624/large/21ab51c6fdec0656327acd1decc6b95f.jpg?1521491898", "sebastian_cavazzoli", "", "", "https://www.instagram.com/sebacavazzoli.art", "", "https://www.youtube.com/sebastiancavazzoli", "Sebastian Cavazzoli" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "IdTag", "TagName" },
                values: new object[,]
                {
                    { new Guid("09b9b49d-8bba-4945-8de4-e2a56feabb22"), "Digital Painting" },
                    { new Guid("0f4a3ee3-8006-43ff-9f14-450e83352ce2"), "Urban Art" },
                    { new Guid("1bb27278-c3c0-4910-be37-2c978aa0e597"), "Typography" },
                    { new Guid("278bf2f7-8ea4-49d6-89af-57cdba17ea52"), "Calligraphy" },
                    { new Guid("2a2a8a52-b096-4788-a9f1-604bab8e2eec"), "Sci-Fi" },
                    { new Guid("5d458006-6af0-4293-afc8-388805314e79"), "Photorealism" },
                    { new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d"), "Street Art" },
                    { new Guid("7af38711-1dff-449e-b400-3b3c1e0c5ce6"), "Abstract" },
                    { new Guid("8914de02-37bb-4df9-8d3c-fc652ee654c0"), "Graffiti" },
                    { new Guid("8f47c5c7-1d60-43bd-b910-08c941ca1a43"), "Character Design" },
                    { new Guid("91e97a37-d394-46c1-9056-3cced711ef97"), "Cubism" },
                    { new Guid("99b58f35-c024-4ca5-9247-318d36335abf"), "Abstract Expressionism" },
                    { new Guid("a9f7f755-e1c5-4c1c-946c-e8878a4ad43e"), "Nature" },
                    { new Guid("b0a7936a-4c23-4213-ad3c-5f53745197e7"), "Minimalism" },
                    { new Guid("b2b9220f-949f-4379-9b2c-d259215e7b20"), "Pixel Art" },
                    { new Guid("b3b265b5-847f-4fc1-b343-4c601d941a06"), "Fantasy" },
                    { new Guid("b6898f28-de2c-4198-9e4c-e857fbaf04a7"), "Digital 2D" },
                    { new Guid("bb5447bc-5b00-4a73-89ce-6c81aa518b4a"), "Comics" },
                    { new Guid("c1a513ee-7361-41f8-b1fb-5d22ae60511e"), "Portrait" },
                    { new Guid("c6d15992-5875-4c1a-802e-c9c254963ace"), "Surrealism" },
                    { new Guid("ccc175b1-c0ba-438f-9ff5-6628bece730c"), "Concept Art" },
                    { new Guid("d2893a9c-95d6-49c8-b669-d6743d955657"), "Animation" },
                    { new Guid("e7ffe31c-a60c-47a4-9c7c-14197683e390"), "Storytelling" },
                    { new Guid("e8214540-73f3-4225-bf88-45eabab70edc"), "Watercolor" },
                    { new Guid("f3b21212-2734-409f-a7b3-d20aff4a8857"), "Impressionism" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "IdArtwork", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new DateTime(2023, 12, 3, 15, 8, 11, 737, DateTimeKind.Local).AddTicks(5226), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Doloremque qui quam modi rem quibusdam vel ratione beatae. Velit architecto natus est quos. Nostrum sed veritatis vitae temporibus aliquam esse qui est. Laboriosam vitae facilis porro. Facere rem ut quidem est blanditiis fugit ipsa rem dolorem.", "Alias alias omnis voluptates voluptas." },
                    { new Guid("22f24ced-61c1-4125-b46d-43422f62e7bf"), new DateTime(2023, 5, 9, 16, 56, 50, 244, DateTimeKind.Local).AddTicks(5733), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Culpa inventore omnis ipsam mollitia sed incidunt praesentium. Et commodi ad dignissimos id. Aut assumenda quam dolor quos officia quaerat. In dolorum necessitatibus at repellat libero sunt sint tempora.", "Autem recusandae fugiat labore tempore molestias magni corrupti." },
                    { new Guid("26257a46-de7c-407f-ab81-48b6b9f3c38c"), new DateTime(2023, 1, 1, 9, 5, 47, 585, DateTimeKind.Local).AddTicks(9332), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Deserunt quos adipisci rem voluptatibus sit exercitationem consequatur. Mollitia maiores omnis quasi voluptatem hic earum nisi facilis autem. Eius dolor doloremque qui eveniet nulla et dicta. Impedit est et sequi accusantium est nam aut. Sit nulla sed dolor iste.", "Sit doloremque quia eveniet facere iure fugiat neque." },
                    { new Guid("2e26f14e-fd5b-4814-8fb2-09777b0aab55"), new DateTime(2023, 5, 28, 11, 18, 29, 305, DateTimeKind.Local).AddTicks(9927), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Odit ratione aut. Magni ea quisquam culpa magni vitae officiis id maiores vel. Deleniti voluptate nobis. Veniam sequi dolorem et neque quia esse sit perspiciatis.", "Reprehenderit laudantium eum." },
                    { new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), new DateTime(2023, 12, 13, 4, 17, 38, 633, DateTimeKind.Local).AddTicks(703), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Rem eveniet est officia voluptas eum omnis illum expedita est. Eum nam eos nihil. Autem dolorem optio accusantium nemo consectetur enim dolores. Cumque libero culpa rerum voluptas.", "Veniam ad commodi." },
                    { new Guid("4df9a024-1d3d-4002-bb8e-f4f5d7ac94c9"), new DateTime(2023, 1, 25, 15, 52, 51, 876, DateTimeKind.Local).AddTicks(1045), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Quisquam veritatis sequi tempora et quod dolor. Quibusdam harum laborum. Molestiae necessitatibus nisi est molestiae. Sit enim et asperiores voluptatum dolorem voluptas laudantium. Quia minima et et hic aut et sed omnis occaecati. Animi officiis sed corporis dolores nesciunt quia quia.", "Nihil consequatur molestiae et delectus autem recusandae et." },
                    { new Guid("73bcb7ea-c460-48bd-8693-9551b27aef2d"), new DateTime(2023, 10, 23, 13, 0, 57, 213, DateTimeKind.Local).AddTicks(7874), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Aut fugiat aut sint porro. Sunt laborum distinctio quo voluptatem eveniet sunt tempora et ut. Voluptas aspernatur occaecati sapiente. Eum voluptatem quo velit sed officia et. Deserunt nemo illo rerum illum necessitatibus sit eius sapiente ducimus.", "Nobis sunt minus incidunt voluptatem aut in." },
                    { new Guid("8fd0689d-5fd4-47c6-bb4d-3d38b624b9f2"), new DateTime(2023, 5, 23, 14, 34, 45, 124, DateTimeKind.Local).AddTicks(7442), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Culpa consequatur perferendis cupiditate non ipsam sint corrupti incidunt. Optio quod quo enim aut aut voluptatem ullam. Optio nihil soluta ut. Est maiores eos cum iure quo nobis fugit ea.", "Necessitatibus voluptates vero." },
                    { new Guid("a4d2f0ca-e445-46ac-831e-8c384380f9cc"), new DateTime(2022, 12, 24, 5, 9, 36, 524, DateTimeKind.Local).AddTicks(5734), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Ut dolorem illo laudantium. Sit sit praesentium aperiam praesentium ut quos. Nam ad in. Qui incidunt ut fuga porro. Non vel quisquam ut. Animi et qui non eum.", "Et et quidem animi voluptatum." },
                    { new Guid("ad8562fd-0417-4815-ac85-d0fb26df0f59"), new DateTime(2023, 8, 2, 3, 44, 37, 523, DateTimeKind.Local).AddTicks(6950), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Possimus facilis quia sed ipsum officiis qui qui molestias. Doloremque ea id voluptates facere fugiat fugiat. Rerum atque quibusdam. Non fugiat voluptatem qui nisi sunt. Qui rerum rerum praesentium molestiae hic iure. Ea quia et iste excepturi nesciunt.", "Et vitae aut et officiis harum." },
                    { new Guid("d500f602-37bf-4de8-a1f8-62086c522dde"), new DateTime(2023, 2, 28, 13, 47, 12, 657, DateTimeKind.Local).AddTicks(3395), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Consequatur sit quo quos sint officia. Dolore eius consequatur harum ratione earum consequatur. Commodi iure voluptatum et quia molestiae quis ut natus voluptatem. Pariatur facere et nihil id. Saepe sit et. Tempore a nulla et eveniet enim exercitationem.", "Placeat id officia voluptas dolor voluptate accusamus." },
                    { new Guid("e49edb7b-926c-4ae6-9dab-4c81bbaf2b23"), new DateTime(2023, 7, 30, 9, 37, 51, 191, DateTimeKind.Local).AddTicks(9832), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Ut non eligendi. Voluptatem ullam odit. Reprehenderit qui et sed sint ea. Perspiciatis quisquam sed nulla voluptas est voluptate repudiandae ea a. Et autem necessitatibus quia id quod perferendis sunt consectetur expedita.", "Blanditiis facilis voluptate." },
                    { new Guid("e6d916b8-4b51-4ab3-b515-1a3b7ba7c1a1"), new DateTime(2023, 11, 13, 0, 4, 32, 383, DateTimeKind.Local).AddTicks(9545), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Harum sed ut aliquid. Mollitia tempora quos ex perferendis et optio similique et fuga. Est vero molestiae. Eos provident rerum. Nam eos ipsam quasi. Omnis at et veniam eum.", "Sed aliquam qui minus neque." },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new DateTime(2023, 10, 19, 20, 8, 29, 875, DateTimeKind.Local).AddTicks(9593), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Iusto quia inventore voluptas expedita laborum eum omnis occaecati. Qui nihil aperiam assumenda eveniet autem. Vel sit libero rerum animi.", "Repellendus id minus eum rerum et magni." },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new DateTime(2023, 2, 24, 4, 37, 9, 690, DateTimeKind.Local).AddTicks(1494), new Guid("28f9b607-474f-403f-9f17-34a6fc6676c1"), "Esse praesentium quibusdam sunt dolores quo non. Ad hic maxime fuga quae suscipit. Delectus perferendis praesentium hic mollitia. Dolorum vitae est. Rerum sint dolores vel libero blanditiis. Suscipit excepturi enim sed dolor possimus quae magni voluptates.", "Ea a aspernatur hic vel ipsa consectetur consequatur." }
                });

            migrationBuilder.InsertData(
                table: "ArtworkTag",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("4df9a024-1d3d-4002-bb8e-f4f5d7ac94c9"), new Guid("0f4a3ee3-8006-43ff-9f14-450e83352ce2") },
                    { new Guid("8fd0689d-5fd4-47c6-bb4d-3d38b624b9f2"), new Guid("0f4a3ee3-8006-43ff-9f14-450e83352ce2") },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new Guid("0f4a3ee3-8006-43ff-9f14-450e83352ce2") },
                    { new Guid("a4d2f0ca-e445-46ac-831e-8c384380f9cc"), new Guid("1bb27278-c3c0-4910-be37-2c978aa0e597") },
                    { new Guid("a4d2f0ca-e445-46ac-831e-8c384380f9cc"), new Guid("278bf2f7-8ea4-49d6-89af-57cdba17ea52") },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new Guid("278bf2f7-8ea4-49d6-89af-57cdba17ea52") },
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new Guid("2a2a8a52-b096-4788-a9f1-604bab8e2eec") },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new Guid("2a2a8a52-b096-4788-a9f1-604bab8e2eec") },
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new Guid("5d458006-6af0-4293-afc8-388805314e79") },
                    { new Guid("73bcb7ea-c460-48bd-8693-9551b27aef2d"), new Guid("5d458006-6af0-4293-afc8-388805314e79") },
                    { new Guid("2e26f14e-fd5b-4814-8fb2-09777b0aab55"), new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d") },
                    { new Guid("4df9a024-1d3d-4002-bb8e-f4f5d7ac94c9"), new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d") },
                    { new Guid("8fd0689d-5fd4-47c6-bb4d-3d38b624b9f2"), new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d") },
                    { new Guid("ad8562fd-0417-4815-ac85-d0fb26df0f59"), new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d") },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new Guid("72db3ce9-f1ff-465f-9cef-78d496f4160d") },
                    { new Guid("4df9a024-1d3d-4002-bb8e-f4f5d7ac94c9"), new Guid("7af38711-1dff-449e-b400-3b3c1e0c5ce6") },
                    { new Guid("e49edb7b-926c-4ae6-9dab-4c81bbaf2b23"), new Guid("7af38711-1dff-449e-b400-3b3c1e0c5ce6") },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new Guid("7af38711-1dff-449e-b400-3b3c1e0c5ce6") },
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new Guid("8f47c5c7-1d60-43bd-b910-08c941ca1a43") },
                    { new Guid("2e26f14e-fd5b-4814-8fb2-09777b0aab55"), new Guid("91e97a37-d394-46c1-9056-3cced711ef97") },
                    { new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), new Guid("b0a7936a-4c23-4213-ad3c-5f53745197e7") },
                    { new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), new Guid("b2b9220f-949f-4379-9b2c-d259215e7b20") },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new Guid("b2b9220f-949f-4379-9b2c-d259215e7b20") },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new Guid("b3b265b5-847f-4fc1-b343-4c601d941a06") },
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new Guid("b6898f28-de2c-4198-9e4c-e857fbaf04a7") },
                    { new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), new Guid("c1a513ee-7361-41f8-b1fb-5d22ae60511e") },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new Guid("c6d15992-5875-4c1a-802e-c9c254963ace") },
                    { new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), new Guid("ccc175b1-c0ba-438f-9ff5-6628bece730c") },
                    { new Guid("8fd0689d-5fd4-47c6-bb4d-3d38b624b9f2"), new Guid("e7ffe31c-a60c-47a4-9c7c-14197683e390") },
                    { new Guid("e49edb7b-926c-4ae6-9dab-4c81bbaf2b23"), new Guid("e7ffe31c-a60c-47a4-9c7c-14197683e390") },
                    { new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), new Guid("e7ffe31c-a60c-47a4-9c7c-14197683e390") },
                    { new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), new Guid("e7ffe31c-a60c-47a4-9c7c-14197683e390") },
                    { new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), new Guid("f3b21212-2734-409f-a7b3-d20aff4a8857") },
                    { new Guid("e49edb7b-926c-4ae6-9dab-4c81bbaf2b23"), new Guid("f3b21212-2734-409f-a7b3-d20aff4a8857") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "IdImage", "ArtworkId", "CloudId", "Order", "Src" },
                values: new object[,]
                {
                    { new Guid("2067b823-8cee-42a7-bcbc-b6a28fc977e2"), new Guid("f6b41168-339d-43be-bb15-0ac734e9beb6"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/070/397/485/20231212212844/smaller_square/sebastian-cavazzoli-2313313.jpg?1702438125" },
                    { new Guid("25c09c68-4a4f-4c48-9539-7e1598ffa061"), new Guid("e6d916b8-4b51-4ab3-b515-1a3b7ba7c1a1"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/052/375/327/20220807090628/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-cheloportada2.jpg?1659881189" },
                    { new Guid("2803c917-5288-40db-a7b3-bcf5485a1503"), new Guid("150d08d9-bdb5-478f-a6a2-88b207fc8cd5"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/038/143/017/smaller_square/sebastian-cavazzoli-7.jpg?1622294979" },
                    { new Guid("30d3c417-35eb-437e-a63d-ea164f10e856"), new Guid("22f24ced-61c1-4125-b46d-43422f62e7bf"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/070/397/631/smaller_square/sebastian-cavazzoli-close2.jpg?1702438582" },
                    { new Guid("30f36dc7-2299-4762-b069-739546fbd913"), new Guid("8fd0689d-5fd4-47c6-bb4d-3d38b624b9f2"), "", 1, "https://cdna.artstation.com/p/assets/covers/images/041/445/024/20210915103933/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-2cc.jpg?1631720373" },
                    { new Guid("590eb79b-b69e-488f-a7cb-c4b9ecf4e5a0"), new Guid("ad8562fd-0417-4815-ac85-d0fb26df0f59"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/064/384/223/smaller_square/sebastian-cavazzoli-1.jpg?1687806929" },
                    { new Guid("74f6aeb0-e140-4b7f-b915-ee9ef5f5ecb5"), new Guid("26257a46-de7c-407f-ab81-48b6b9f3c38c"), "", 1, "https://cdna.artstation.com/p/assets/covers/images/037/967/798/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-3.jpg?1621816194" },
                    { new Guid("91a4bacf-9c0d-4ca3-86e4-074222cf0465"), new Guid("73bcb7ea-c460-48bd-8693-9551b27aef2d"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/036/813/465/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-1.jpg?1618687643" },
                    { new Guid("a9e808ea-4e2c-460d-9740-cb04162189a6"), new Guid("2e26f14e-fd5b-4814-8fb2-09777b0aab55"), "", 1, "https://cdna.artstation.com/p/assets/video_clips/images/045/020/050/smaller_square/sebastian-cavazzoli-thumb.jpg?1641742817" },
                    { new Guid("ac6d86f4-f434-46ba-b930-4b8dfd65d70d"), new Guid("a4d2f0ca-e445-46ac-831e-8c384380f9cc"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/055/727/009/smaller_square/sebastian-cavazzoli-1.jpg?1667597373" },
                    { new Guid("ae4e5710-595f-492f-af42-3b9243388c0a"), new Guid("4df9a024-1d3d-4002-bb8e-f4f5d7ac94c9"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/062/527/639/smaller_square/sebastian-cavazzoli-04a4ddc0-1c5c-42a3-b4ff-5e8c77014ad4.jpg?1683333990" },
                    { new Guid("d9068280-3ee9-470b-8486-c31a29027d21"), new Guid("30554c9d-9e81-4c3f-8a51-a39cacdf4089"), "", 1, "https://cdnb.artstation.com/p/assets/images/images/058/444/123/smaller_square/sebastian-cavazzoli-1b.jpg?1674161052" },
                    { new Guid("e9da5353-7cd2-4550-9f10-1fbf1c86f2ed"), new Guid("e49edb7b-926c-4ae6-9dab-4c81bbaf2b23"), "", 1, "https://cdnb.artstation.com/p/assets/covers/images/034/485/459/20210203223805/smaller_square/sebastian-cavazzoli-sebastian-cavazzoli-01.jpg?1612413485" },
                    { new Guid("ee6f7bf2-dbb6-41da-beac-f531e2a98de1"), new Guid("f7140316-7c2a-4876-b479-f2cbcafa8b61"), "", 1, "https://cdna.artstation.com/p/assets/images/images/036/831/246/20210418093453/smaller_square/sebastian-cavazzoli-widefsnew.jpg?1618756493" },
                    { new Guid("f76d742f-e590-4324-995a-a9f9e514e33b"), new Guid("d500f602-37bf-4de8-a1f8-62086c522dde"), "", 1, "https://cdnb.artstation.com/p/assets/video_clips/images/066/131/241/smaller_square/sebastian-cavazzoli-thumb.jpg?1692121620" }
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
                name: "IX_Images_ArtworkId",
                table: "Images",
                column: "ArtworkId");
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
