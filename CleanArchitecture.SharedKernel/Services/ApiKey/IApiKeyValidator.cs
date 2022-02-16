using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Services.ApiKey;

public interface IApiKeyValidator
{
    Task<IEnumerable<Claim>> ValidateAsync(Guid apiKeyToken);
}
