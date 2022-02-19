namespace CleanArchitecture.SharedKernel.Modules.Jwt;

public partial class RefreshToken
{
    public int UserId { get; set; }
    public string Token { get; set; } = null!;
    public DateTime ExpiresAtUtc { get; set; }

}
