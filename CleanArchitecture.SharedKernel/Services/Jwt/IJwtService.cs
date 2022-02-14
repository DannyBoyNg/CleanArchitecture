using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        public JwtToken GenerateJwtToken(IEnumerable<Claim> claims);
        public JwtToken GenerateJwtTokenFromExistingAccessToken(string accessToken, bool allowExpiredTokens = false);
        string GenerateRefreshToken();
        string? GetClaim(ClaimsPrincipal claimsIdentity, string claimType);
        ClaimsPrincipal GetClaimsFromAccessToken(string accessToken);
        ClaimsPrincipal GetClaimsFromExpiredAccessToken(string accessToken);
        DateTime GetCreationTimeFromRefreshToken(string token);
        bool IsRefreshTokenExpired(string token);
    }
}