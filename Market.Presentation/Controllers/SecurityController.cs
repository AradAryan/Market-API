using Market.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecurityController : BaseController<SecurityController>
    {
        public SecurityController(ILogger<SecurityController> logger) : base(logger)
        {

        }

        [HttpGet]
        public IActionResult IsAuthorized()
        {
            return Ok(new { IsAuthorized = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize(UserModel user)
        {
            if (user.UserName == "sls123" && user.Password == "sls123")
            {
                string issuer = "TEST";
                string audience = "arad";
                byte[] key = Encoding.ASCII.GetBytes("This is a sample secret key - please don't use in production environment.");

                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                JwtSecurityTokenHandler tokenHandler = new();
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = tokenHandler.WriteToken(token);
                string stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            return Unauthorized(new { Result = "Wrong Credential!" });
        }
    }
}
