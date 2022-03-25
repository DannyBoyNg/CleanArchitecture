using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.WebApi.Endpoints.ApiKey;

[ApiController]
public class UpdateOrder : ControllerBase
{
    private readonly IRepository<Order> repo;
    private readonly IMapper mapper;

    public UpdateOrder(IRepository<Order> repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    [HttpPost("Orders/Update")]
    [SwaggerOperation(OperationId = "Order.Update", Tags = new[] { "OrderEndpoint" })]
    public async Task<ActionResult> Handle(OrderDto orderDto)
    {
        var order = mapper.Map<Order>(orderDto);
        await repo.UpdateAsync(order);
        return NoContent();
    }
}

