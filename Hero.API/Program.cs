using Hero.API.Data;
using Hero.API.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeroDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HeroConnection"), sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
        .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
            .AsSelf()
            .WithScopedLifetime()
        .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
            .AsSelf()
            .WithScopedLifetime()
);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7230")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();



app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HeroDbContext>();

    context.Database.Migrate();

    SceneSeeder.SeedScenes(context);
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();