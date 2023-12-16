
using ArtLite.Api;
using ArtLite.Api.Persistence;
using ArtLite.Api.Services;
using ArtLite.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddTransient<DataGenerator>();
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(
            "Server=.;Database=DbArtLite;TrustServerCertificate=True;Trusted_Connection=True",
            sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
        );
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
    });

    // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
    services.Configure<CloudinarySettings>(configuration.GetSection(CloudinarySettings.SectionName));

    services.AddScoped<IArtworkService, ArtworkService>();
    services.AddScoped<ICreatorService, CreatorService>();
    services.AddScoped<ITagService, TagService>();
    services.AddScoped<IImageUploader, CloudinaryService>();


    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:3000")
        );
    });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();    
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("CorsPolicy");
    app.MapControllers();

    app.Run();
}


