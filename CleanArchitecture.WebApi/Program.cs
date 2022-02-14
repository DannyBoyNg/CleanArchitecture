using CleanArchitecture.SharedKernel;
using CleanArchitecture.Core;
using CleanArchitecture.WebApi;
using CleanArchitecture.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the DI container.
builder.Host.AddHostBuilderExtensions();
builder.Services.AddSharedKernelServices(configuration);
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddCoreServices(configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(options => options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms");
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler(GlobalErrorHandler.Configuration);
app.MapControllers();
app.Run();
