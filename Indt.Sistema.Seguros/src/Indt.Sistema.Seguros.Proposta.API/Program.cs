using Indt.Sistema.Seguros.Infra.DataBase.EntityFramework;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using System.Reflection;
using Indt.Sistema.Seguros.Infra.DataBase;
using Indt.Sistema.Seguros.App.API;
using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.File
             (
                "Logs/contatoApp.text",
                outputTemplate: "{Timestamp:o} [{Level:u3}] ({Application}/{MachineName}/{ThreadId}) {Message}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 10 * 1024 * 1024,
                retainedFileCountLimit: 2,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
             .ReadFrom.Configuration(configuration)
             .Enrich.FromLogContext()
             .CreateLogger();

//builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

//builder.Services.AddTransient<TelemetryMiddleware>();

//var hcBuilder = builder.Services.AddHealthChecks();
//var connectionString = configuration.GetConnectionString("DefaultConnection");
//hcBuilder.AddSqlServer(connectionString, name: "Sql Server");


// Add services to the container.

var options = new DbOptions(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("Prefix"));
builder.Services.AddSingleton(options);
builder.Services.AddSqlServerProvider(options);
builder.Services.AddApplication();
//builder.Services.AddDomainService();
builder.Services.AddRepository();
// Registro do MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CriarPropostaRequest).Assembly);
});
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.EnableAnnotations();
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Contato API",
        Description = "API responsável por inserir contatos"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        opt.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
