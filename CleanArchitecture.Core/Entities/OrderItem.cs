namespace CleanArchitecture.Core.Entities;

public partial class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;
}
