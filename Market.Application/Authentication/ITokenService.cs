using Market.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Market.Application.Authentication
{
    public interface ITokenService
    {
        JwtSecurityToken GetToken(List<Claim> authClaims);
        string BuildToken(string key, string issuer, UserModel user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}