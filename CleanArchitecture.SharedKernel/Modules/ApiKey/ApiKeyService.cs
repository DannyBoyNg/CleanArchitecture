using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.SharedKernel.Modules.ApiKey;

public class ApiKeyService
{
    private readonly IRepository<ApiKey> apiKeyRepo;

    public ApiKeyService(IRepository<ApiKey> apiKeyRepo)
    {
        this.apiKeyRepo = apiKeyRepo;
    }

    public async Task<ApiKey> CreateAsync(string clientName, int userId)
    {
        var t = new ApiKey
        {
            Token = new Guid(),
            ClientName = clientName,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userId,
        };
        return await apiKeyRepo.AddAsync(t);
    }

    public async void RevokeAsync(Guid token, int userId)
    {
        var apiToken = await apiKeyRepo.GetByIdAsync(token);
        if (apiToken == null) throw new ApiKeyInvalidException();
        apiToken.Revoked = true;
        apiToken.RevokedAt = DateTime.UtcNow;
        apiToken.RevokedBy = userId;
        await apiKeyRepo.UpdateAsync(apiToken);
    }

    public async void DeleteAsync(Guid token)
    {
        var apiToken = await apiKeyRepo.GetByIdAsync(token);
        if (apiToken == null) throw new ApiKeyInvalidException();
        await apiKeyRepo.DeleteAsync(apiToken);
    }
}

