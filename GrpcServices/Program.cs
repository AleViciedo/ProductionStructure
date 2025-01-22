using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.DataAccess;
using ProductionStructure.DataAccess.Context;
using ProductionStructure.DataAccess.Repositories.ConfigurationData;
using ProductionStructure.DataAccess.Repositories.HistoricalData;
using ProductionStructure.GrpcServices.Services;
using ProductionStructure.GrpcServices.Services.ConfigurationData;
using ProductionStructure.GrpcServices.Services.HistoricalData;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton("Data Source=Data.qlite");
builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IWorkCenterRepository, WorkCenterRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IWorkSessionRepository, WorkSessionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<WorkSessionService>();
app.MapGrpcService<UnitService>();
app.MapGrpcService<WorkCenterService>();
app.MapGrpcService<AreaService>();
app.MapGrpcService<SiteService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
