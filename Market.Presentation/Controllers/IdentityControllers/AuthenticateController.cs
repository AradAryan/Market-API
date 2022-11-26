using Market.Application.Authentication;
using Market.Domain.Models.Authentication;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController<AuthenticateController>
    {
        public IUserApplicationService UserApplicationService { get; }

        public AuthenticateController(
            IUserApplicationService userApplicationService,
            ILogger<AuthenticateController> logger) : base(logger)
        {
            UserApplicationService = userApplicationService;
        }

        [HttpGet]
        [Route("IsAuthorized")]
        [Authorize]
        public IActionResult IsAuthorized()
        {
            return Ok(new { IsAuthorized = true });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return ReturnResponse(await UserApplicationService.Login(model));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await UserApplicationService.CreateUser(model);
            return ReturnResponse(result);
        }

    }
}
