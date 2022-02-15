using CleanArchitecture.Infrastructure.Persistence.Entities;
using CleanArchitecture.Infrastructure.Persistence.Exceptions;
using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.Services;

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
        if (apiToken == null) throw new DbEntityNotFoundException();
        apiToken.Revoked = true;
        apiToken.RevokedAt = DateTime.UtcNow;
        apiToken.RevokedBy = userId;
        await apiKeyRepo.UpdateAsync(apiToken);
    }

    public async void DeleteAsync(Guid token)
    {
        var apiToken = await apiKeyRepo.GetByIdAsync(token);
        if (apiToken == null) throw new DbEntityNotFoundException();
        await apiKeyRepo.DeleteAsync(apiToken);
    }
}

