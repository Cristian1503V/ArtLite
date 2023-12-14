
using ArtLite.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    var configuration = builder.Configuration;

    // services.AddDbContext<AppDbContext>(options =>
    // {
    //     options.UseSqlServer("Server=.;Database=DbArtStationLite;TrustServerCertificate=True;Trusted_Connection=True");
    //     options.EnableSensitiveDataLogging();
    // });

    // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
    services.Configure<CloudinarySettings>(configuration.GetSection(CloudinarySettings.SectionName));


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

    app.MapControllers();

    app.Run();
}


