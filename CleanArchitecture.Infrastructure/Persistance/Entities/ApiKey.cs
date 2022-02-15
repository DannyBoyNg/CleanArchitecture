using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence.Entities;

public class ApiKey : IAggregateRoot
{
    public Guid Token { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool Revoked { get; set; }
    public DateTime? RevokedAt { get; set; }
    public int? RevokedBy { get; set; }
}

