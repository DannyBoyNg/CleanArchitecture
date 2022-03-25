using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.WebApi.Endpoints.ApiKey;

[ApiController]
public class DeleteOrder : ControllerBase
{
    private readonly IRepository<Order> repo;

    public DeleteOrder(IRepository<Order> repo)
    {
        this.repo = repo;
    }

    [HttpPost("Orders/Delete")]
    [SwaggerOperation(OperationId = "Order.Delete", Tags = new[] { "OrderEndpoint" })]
    public async Task<ActionResult> Handle(int orderId)
    {
        var order = await repo.GetByIdAsync(orderId);
        if (order == null) return BadRequest();
        await repo.DeleteAsync(order);
        return NoContent();
    }
}

