using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.WebApi.Endpoints.ApiKey;

[ApiController]
public class CreateOrder : ControllerBase
{
    private readonly IRepository<Order> repo;
    private readonly IMapper mapper;

    public CreateOrder(IRepository<Order> repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    [HttpPost("Orders/Create")]
    [SwaggerOperation(OperationId = "Order.Create", Tags = new[] { "OrderEndpoint" })]
    public async Task<ActionResult> Handle(OrderDto orderDto)
    {
        var order = mapper.Map<Order>(orderDto);
        await repo.AddAsync(order);
        return NoContent();
    }
}

