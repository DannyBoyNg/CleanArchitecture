using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Services.ApiKey;

public interface IApiKeyValidationService
{
    Task<IEnumerable<Claim>> ValidateAsync(Guid apiKeyToken);
}
