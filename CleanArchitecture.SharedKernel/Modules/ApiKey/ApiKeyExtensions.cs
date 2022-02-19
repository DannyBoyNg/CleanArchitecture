using Microsoft.AspNetCore.Authentication;

namespace CleanArchitecture.SharedKernel.Modules.ApiKey;

public static class ApiKeyExtensions
{
    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder)
    {
        return builder.AddApiKey(ApiKeyDefaults.AuthenticationScheme, delegate{});
    }

    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, Action<ApiKeyOptions> configureOptions)
    {
        return builder.AddApiKey(ApiKeyDefaults.AuthenticationScheme, configureOptions);
    }

    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, string authenticationScheme, Action<ApiKeyOptions> configureOptions)
    {
        return builder.AddApiKey(authenticationScheme, null, configureOptions);
    }

    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, string authenticationScheme, string? displayName, Action<ApiKeyOptions> configureOptions)
    {
        return builder.AddScheme<ApiKeyOptions, ApiKeyHandler>(authenticationScheme, displayName, configureOptions);
    }
}
