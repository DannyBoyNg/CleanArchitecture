using System.Security.Claims;

namespace CleanArchitecture.SharedKernel.Services.Jwt
{
    //Help convert claims to strings
    public static class ClaimsHelper
    {
        public static string? GetClaim(ClaimsPrincipal claimsIdentity, string claimType)
        {
            if (claimsIdentity == null) throw new ArgumentNullException(nameof(claimsIdentity));
            var claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == claimType);
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }

        public static List<string>? GetClaims(ClaimsPrincipal claimsIdentity, string claimType)
        {
            if (claimsIdentity == null) throw new ArgumentNullException(nameof(claimsIdentity));
            var claims = claimsIdentity.Claims.Where(x => x.Type == claimType && !string.IsNullOrWhiteSpace(x.Value)).Select(x => x.Value).ToList();
            if (claims.Count > 0)
            {
                return claims;
            }
            return null;
        }
    }
}
