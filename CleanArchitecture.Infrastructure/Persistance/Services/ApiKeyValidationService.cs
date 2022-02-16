using CleanArchitecture.Infrastructure.Persistence.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using CleanArchitecture.SharedKernel.Services.ApiKey;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Persistence.Services;

public class ApiKeyValidationService : IApiKeyValidator
{
    private readonly IRepository<ApiKey> repo;

    public ApiKeyValidationService(IRepository<ApiKey> repo)
    {
        this.repo = repo;
    }

    public async Task<IEnumerable<Claim>> ValidateAsync(Guid apiKeyToken)
    {
        var t = await repo.GetByIdAsync(apiKeyToken);
        if (t == null) throw new ApiKeyInvalidException();
        if (t.Revoked) throw new ApiKeyRevokedException();
        return new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, t.Token.ToString()),
            new Claim(ClaimTypes.Name, t.ClientName),
        };
    }
}

