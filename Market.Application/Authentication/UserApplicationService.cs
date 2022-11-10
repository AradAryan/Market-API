using Market.Domain.Models;
using Market.Domain.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Authentication
{
    public class UserApplicationService : IUserApplicationService
    {
        private UserManager<IdentityUser> UserManager { get; }
        private ITokenService TokenService { get; }

        public UserApplicationService(
            UserManager<IdentityUser> userManager,
            ITokenService tokenService)
        {
            UserManager = userManager;
            TokenService = tokenService;
        }

        public async Task<ResponseModel> CreateUser(RegisterModel model)
        {
            try
            {
                var userExists = await UserManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    return new ResponseModel { Succeed = false, Message = "User Already Exists!" };

                IdentityUser user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return new ResponseModel { Succeed = false, Message = "User creation failed! Please check user details and try again." };

                return new ResponseModel { Succeed = true, Message = "User Created Successfully!" };
            }
            catch (Exception)
            {
                return new ResponseModel { Succeed = false, Message = "Unhandled Exception!" };
            }
        }

        public async Task<ResponseModel> Login(LoginModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await UserManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = TokenService.GetToken(authClaims);

                return new()
                {
                    Succeed = true,
                    Data = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    }
                };
            }
            return new()
            {
                Succeed = false,
                Message = "Password Validation Failed!"
            };
        }

    }
}
