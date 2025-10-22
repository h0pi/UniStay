using UniStay.API;
using UniStay.API.Middlewares;
using UniStay.Application;
using UniStay.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// 0) Bootstrap logger
// ---------------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting UniStay API...");

    // ---------------------------------------------------------
    // 1) Standard builder
    // ---------------------------------------------------------
    builder.Host.UseSerilog((ctx, services, cfg) =>
    {
        cfg.ReadFrom.Configuration(ctx.Configuration)
           .ReadFrom.Services(services)
           .Enrich.FromLogContext()
           .Enrich.WithThreadId()
           .Enrich.WithProcessId()
           .Enrich.WithMachineName();
    });

    builder.Logging.ClearProviders();

    // ---------------------------------------------------------
    // 2) Layer registrations (tvoje postojeće)
    // ---------------------------------------------------------
    builder.Services
        .AddAPI(builder.Configuration, builder.Environment)
        .AddInfrastructure(builder.Configuration, builder.Environment)
        .AddApplication();

    // ---------------------------------------------------------
    // 3) CORS for Angular frontend
    // ---------------------------------------------------------
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngular",
            policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Angular URL
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
    });

    var app = builder.Build();

    // ---------------------------------------------------------
    // 4) Middleware pipeline
    // ---------------------------------------------------------
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler();
    app.UseMiddleware<RequestResponseLoggingMiddleware>();

    app.UseHttpsRedirection();
    app.UseCors("AllowAngular");       // <-- Angular CORS
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    // Database migrations + seeding
    await app.Services.InitializeDatabaseAsync(app.Environment);

    Log.Information("UniStay API started successfully.");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "UniStay API terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
