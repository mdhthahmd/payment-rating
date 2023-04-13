using Ratings.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Ratings.Api;
using Serilog;
using Ratings.Application.Controllers.Helpers;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Infrastructure.Repositories;
using Ratings.Application.Queries;
using Microsoft.Extensions.FileProviders;
using Ratings.Application.Commands.AddPayment;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information($"App is starting ({DateTime.UtcNow})...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, config) => config
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration)
    );

    builder.Services.AddDbContext<RatingContext>(options =>
        {
            options.UseSqlServer(builder.Configuration["ConnectionString"],
                sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(RatingContext).Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                   });
            options.LogTo(Console.WriteLine);
            options.EnableSensitiveDataLogging();
        },
        ServiceLifetime.Scoped
    );

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSingleton<IUriHelper>(o =>
    {
        var accessor = o.GetRequiredService<IHttpContextAccessor>();
        var request = accessor.HttpContext.Request;
        var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());

        if(builder.Environment.IsDevelopment())
        {
            uri = "https://localhost:5175/payment-rating";
        }
        
        return new UriHelper(uri);
    });


    builder.Services.AddTransient<IEmployerRepository, EmployerRepository>();
    builder.Services.AddTransient<IRatingQueries, RatingQueries>();


    builder.Services.AddControllers()
        .AddApplicationPart(typeof(UriHelper).Assembly);


    builder.Services.AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(typeof(AddPaymentCommand).Assembly);
    });
    
    // builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
    // builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    Log.Information("Applying migrations ({ApplicationContext})...", "Ratings.Api");
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<RatingContext>();
    var env = app.Services.GetService<IWebHostEnvironment>();
    var logger = app.Services.GetService<ILogger<RatingContextSeed>>();
    await context.Database.MigrateAsync();

    await new RatingContextSeed().SeedAsync(context, logger);

    if(!app.Environment.IsDevelopment())
    {   
        app.UseHsts();
        app.UseHttpsRedirection();
        
        DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            options.RedirectToAppendTrailingSlash = false;
            options.RequestPath = "/payment-rating";


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

}
catch(Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information($"Exiting ({DateTime.UtcNow})...");
    Log.CloseAndFlush();
}
