using CleanArchitecture.SharedKernel.Interfaces;
using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Modules.ApiKey;

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IRepository<ApiKey> repo;

    public ApiKeyValidator(IRepository<ApiKey> repo)
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

