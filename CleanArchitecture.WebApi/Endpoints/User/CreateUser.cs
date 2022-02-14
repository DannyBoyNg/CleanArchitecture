using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.WebApi.Endpoints.User;

[Authorize]
[ApiController]
[Route("api")]
public class CreateUser : ControllerBase
{
    public CreateUser()
    {
    }

    [HttpPost("users")]
    [SwaggerOperation(Summary = "Creates an user", Description = "Creates an user", OperationId = "User.Create", Tags = new[] { "UserEndpoint" })]
    public ActionResult HandleAsync(CreateUserRequest req)
    {
        //var user = await userService.CreateUserAsync(req.Name, req.Password, req.Email);
        //throw new InvalidOperationException();
        //return Ok(user);
        return Ok();
    }
}

