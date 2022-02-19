using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.SharedKernel.Services.UserManagement;

public partial class User : IAggregateRoot
{
    public int Id { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool Active { get; set; }
    public bool Deleted { get; set; }

}

