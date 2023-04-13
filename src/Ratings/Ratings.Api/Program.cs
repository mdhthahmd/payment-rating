using Ratings.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<RatingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(RatingContext).Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
                // options.LogTo(Console.WriteLine);
            },
        ServiceLifetime.Scoped
    );

var app = builder.Build();


if(!app.Environment.IsDevelopment())
{   
    app.UseHsts();
    app.UseHttpsRedirection();
    
    DefaultFilesOptions options = new DefaultFilesOptions();
        options.DefaultFileNames.Clear();
        options.DefaultFileNames.Add("index.html");
        options.RedirectToAppendTrailingSlash = false;
        options.RequestPath = "/dotnet-hosting";


    app.UseDefaultFiles(options);

    app.UseStaticFiles(new StaticFileOptions{
        FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
            RequestPath = "/payment-rating",
            RedirectToAppendTrailingSlash = false
    });

    app.UsePathBase("/payment-rating");

}

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
