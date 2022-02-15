using CleanArchitecture.SharedKernel.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.WebApi.Endpoints.Token;

[ApiController]
public class RefreshToken : ControllerBase
{
    private readonly IJwtService jwtService;

    public RefreshToken(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }

    [HttpPost("refreshToken")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Refreshes a Jwt Token", Description = "Refreshes a Jwt Token", OperationId = "Token.Refresh", Tags = new[] { "TokenEndpoint" })]
    public ActionResult<JwtToken> Handle(RefreshTokenRequest req)
    {
        //validate refresh token


        //create new token
        var newJwtToken = jwtService.GenerateJwtTokenFromExistingAccessToken(req.AccessToken);

        //store refresh token in database and remove old one


        //return new 
        return Ok(newJwtToken);

    }
}
