using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.SharedKernel.Services.UserManagement;

namespace CleanArchitecture.WebApi.Endpoints.User;

[Authorize]
[ApiController]
public class CreateUser : ControllerBase
{

    public CreateUser()
    {

    }

    [HttpPost("users")]
    [SwaggerOperation(Summary = "Creates an user", Description = "Creates an user", OperationId = "User.Create", Tags = new[] { "UserEndpoint" })]
    public IActionResult Handle(CreateUserRequest req)
    {
        return Ok(req);
    }
}

