using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Modules.ApiKey;

public interface IApiKeyValidator
{
    Task<IEnumerable<Claim>> ValidateAsync(Guid apiKeyToken);
}
