using Microsoft.AspNetCore.Authentication;

namespace CleanArchitecture.SharedKernel.Services.ApiKey
{
    public class ApiKeyOptions : AuthenticationSchemeOptions
    {
        public string ApiKeyHeader { get; set; } = "API-KEY";
    }
}