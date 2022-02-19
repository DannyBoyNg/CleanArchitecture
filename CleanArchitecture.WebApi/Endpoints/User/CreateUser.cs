using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.SharedKernel.Services.UserManagement;

namespace CleanArchitecture.WebApi.Endpoints.User;

[Authorize]
[ApiController]
public class CreateUser : ControllerBase
{
    private readonly UserService userService;

    public CreateUser(UserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("users")]
    [SwaggerOperation(Summary = "Creates an user", Description = "Creates an user", OperationId = "User.Create", Tags = new[] { "UserEndpoint" })]
    public async Task<ActionResult> Handle(CreateUserRequest req)
    {
        //var user = await userService.CreateUserAsync(req.Name, req.Password, req.Email);
        return Ok();
    }
}

