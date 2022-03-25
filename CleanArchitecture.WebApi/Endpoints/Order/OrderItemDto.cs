namespace CleanArchitecture.Core.Entities;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
}
