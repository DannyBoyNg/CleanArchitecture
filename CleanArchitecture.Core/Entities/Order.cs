using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.Core.Entities;

public partial class Order : IAggregateRoot
{
    public Order()
    {
        OrderItems = new HashSet<OrderItem>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
