namespace CleanArchitecture.Core.Entities;

public class OrderDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<OrderItemDto> OrderItems { get; set; } = null!;
}
