using Market.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserController>
    {
        public UserManager<ApplicationUser> UserManager { get; set; }

        public UserController(ILogger<UserController> logger, UserManager<ApplicationUser> userManager) : base(logger)
        {
            UserManager = userManager;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            //await UserManager.get;
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            //await UserManager.GetUserAsync;
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(string password, ApplicationUser user)
        {
            var result = await UserManager.CreateAsync(user, password);
            var data =
                new ReturnModel<ApplicationUser, IEnumerable<IdentityError>>
                {
                    Succeed = result.Succeeded,
                    Error = result.Errors,
                    Data = null
                };
            return Ok(data);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
