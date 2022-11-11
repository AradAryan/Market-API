using Market.Application.Authentication;
using Market.Domain.Models;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseController<RoleController>
    {
        public IRoleApplicationService RoleApplicationService { get; }

        public RoleController(
            IRoleApplicationService roleApplicationService,
            ILogger<RoleController> logger) : base(logger)
        {
            RoleApplicationService = roleApplicationService;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            return ReturnResponse(await RoleApplicationService.CreateRole(roleName));
        }

        [HttpPost]
        [Authorize]
        [Route("AssignRole")]
        public async Task<IActionResult> AssignRole(string username, string roleName)
        {
            return ReturnResponse(await RoleApplicationService.AssignRole(username, roleName));
        }
    }
}
