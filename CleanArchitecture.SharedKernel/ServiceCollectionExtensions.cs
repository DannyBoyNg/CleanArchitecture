using CleanArchitecture.SharedKernel.Services.ApiKey;
using CleanArchitecture.SharedKernel.Services.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.SharedKernel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedKernelServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Decide which authentication scheme should be used
        services
            .AddAuthentication("SchemeSelector")
            .AddPolicyScheme("SchemeSelector", "Select an authentication scheme", options => {
                options.ForwardDefaultSelector = context =>
                {
                    var headers = context.Request.Headers;
                    return headers switch
                    {
                        var x when x["X-Api-Key"].FirstOrDefault() != null => ApiKeyDefaults.AuthenticationScheme,
                        _ => JwtBearerDefaults.AuthenticationScheme
                    };
                };
            });

        //Jwt authentication
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            ValidateLifetime = true,
            SaveSigninToken = true,
        };
        services
            .AddAuthentication()
            .AddJwtBearer(options => options.TokenValidationParameters = tokenValidationParameters);
        services.AddScoped<IJwtService, JwtService>();
        services.Configure<JwtSettings>(options => options.TokenValidationParameters = tokenValidationParameters);

        //Api Key authentication
        services
            .AddAuthentication()
            .AddScheme<ApiKeyOptions, ApiKeyHandler>(ApiKeyDefaults.AuthenticationScheme, null);

        //CORS
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins(new string[] { "http://localhost", "http://localhost:4200", "https://localhost:4200" })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders(new string[] { "Content-Disposition", "WWW-Authenticate" })
                .AllowCredentials());
        });

        return services;
    }
}
