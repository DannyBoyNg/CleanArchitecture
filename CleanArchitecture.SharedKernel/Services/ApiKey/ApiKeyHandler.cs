using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace CleanArchitecture.SharedKernel.Services.ApiKey
{
    public class ApiKeyHandler : AuthenticationHandler<ApiKeyOptions>
    {
        private readonly IApiKeyValidator apiKeyValidator;

        public ApiKeyHandler(
            IOptionsMonitor<ApiKeyOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyValidator apiKeyValidator)
            : base(options, logger, encoder, clock)
        {
            this.apiKeyValidator = apiKeyValidator;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Get api key from header
            if (!Request.Headers.TryGetValue(Options.ApiKeyHeader, out var apiKey))
            {
                return AuthenticateResult.NoResult();
            }

            //Parse Guid
            if (!Guid.TryParse(apiKey, out var guid)) return AuthenticateResult.Fail(new ApiKeyInvalidException());

            //check is api key is valid
            var claims = await apiKeyValidator.ValidateAsync(guid);
            return Success(claims);
        }

        private AuthenticateResult Success(IEnumerable<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}