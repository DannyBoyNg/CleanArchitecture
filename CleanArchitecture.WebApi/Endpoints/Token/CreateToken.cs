using CleanArchitecture.SharedKernel.Modules.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Endpoints.Token;

[ApiController]
public class CreateToken : ControllerBase
{
    private readonly IJwtService jwtService;

    public CreateToken(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }

    [HttpPost("Token")]
    [SwaggerOperation(Summary = "Creates a Jwt Token", Description = "Creates a Jwt Token", OperationId = "Token.Create", Tags = new[] { "TokenEndpoint" })]
    public ActionResult<JwtToken> Handle(CreateTokenRequest _)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, "TestUser"),
            new Claim("uid", "1"),
        };

        return Ok(jwtService.GenerateJwtToken(claims));
    }
}
