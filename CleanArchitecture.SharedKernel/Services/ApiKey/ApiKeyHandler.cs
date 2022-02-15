using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace CleanArchitecture.SharedKernel.Services.ApiKey
{
    public class ApiKeyHandler : AuthenticationHandler<ApiKeyOptions>
    {
        private readonly IApiKeyValidationService apiKeyValidationService;

        public ApiKeyHandler(
            IOptionsMonitor<ApiKeyOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyValidationService apiKeyValidationService)
            : base(options, logger, encoder, clock)
        {
            this.apiKeyValidationService = apiKeyValidationService;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Get api key from header
            if (!Request.Headers.TryGetValue("API-KEY", out var apiKey))
            {
                return AuthenticateResult.NoResult();
            }

            //Parse Guid
            if (!Guid.TryParse(apiKey, out var guid)) throw new ApiKeyInvalidException();

            //check is api key is valid
            var claims = await apiKeyValidationService.ValidateAsync(guid);
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