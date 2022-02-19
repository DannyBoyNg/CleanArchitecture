using Microsoft.AspNetCore.Authentication;

namespace CleanArchitecture.SharedKernel.Modules.ApiKey;

public class ApiKeyOptions : AuthenticationSchemeOptions
{
    public string ApiKeyHeader { get; set; } = "API-KEY";
}
