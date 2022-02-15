using CleanArchitecture.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.WebApi.Endpoints.ApiKey;

[ApiController]
public class CreateApiKey : ControllerBase
{
    private readonly ApiKeyService apiKeyService;

    public CreateApiKey(ApiKeyService apiKeyService)
    {
        this.apiKeyService = apiKeyService;
    }

    [HttpPost("apikey")]
    [SwaggerOperation(Summary = "Creates a ApiKey Token", Description = "Creates a ApiKey Token", OperationId = "ApiKey.Create", Tags = new[] { "ApiKeyEndpoint" })]
    public async Task<ActionResult> Handle()
    {
        return Ok(await apiKeyService.CreateAsync("TestClient",0));
    }
}

