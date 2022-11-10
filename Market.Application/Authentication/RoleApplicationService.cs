using Market.Domain.Models;
using Market.Domain.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Authentication
{
    public class RoleApplicationService : IRoleApplicationService
    {
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public IConfiguration Configuration { get; }

        public RoleApplicationService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            Configuration = configuration;
        }

        public async Task<ResponseModel> CreateRole(string roleName)
        {
            try
            {
                if (await RoleManager.RoleExistsAsync(roleName))
                    return new() { Succeed = false, Message = "Role Already Exists!" };

                var result = await RoleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (result.Succeeded)
                    return new()
                    {
                        Succeed = true,
                        Message = "Role Created Successfully!"
                    };
                else
                    return new()
                    {
                        Succeed = false,
                        Message = result.Errors.FirstOrDefault()?.Description,
                    };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel> AssignRole(string username, string roleName)
        {
            if (!await RoleManager.RoleExistsAsync(roleName))
                return new()
                {
                    Succeed = false,
                    Message = "Role Not Exists!",
                    Data = default
                };

            var user = UserManager.Users.Where(c => c.UserName == username).FirstOrDefault();
            if (user is null)
                return new()
                {
                    Succeed = true,
                    Message = "User NotFound!"
                };

            var result = await UserManager.AddToRoleAsync(user, UserRoles.Admin);
            if (result.Succeeded)
                return new()
                {
                    Succeed = true,
                    Message = "Role Assigned Successfully!"
                };
            else
                return new()
                {
                    Succeed = false,
                    Message = result.Errors.FirstOrDefault()?.Description,
                };
        }

    }
}
