using Market.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ILogger Logger { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }

        public BaseController(ILogger logger, UserManager<ApplicationUser> userManager)
        {
            Logger = logger;
            UserManager = userManager;
        }

    }
}
