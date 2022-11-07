using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private UserManager<ApplicationUser> _userManager = null;
        private SignInManager<ApplicationUser> _signInManager = null;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult Index()
        {
            var result = _userManager.CreateAsync(
                new()
                {
                    UserName = "bob",
                    Email = "bob@bob.com"
                }, "Test123!").Result;

            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(Name = "GetUser")]
        public IActionResult Index1()
        {
            var user = _userManager.FindByNameAsync("bob").Result;
            var result = _signInManager.CheckPasswordSignInAsync(user, "Test123!", false).Result;
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }

        //[HttpPost(Name = "Test")]
        //public async Task<IActionResult> Index2()
        //{
        //    return Ok();
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

    }
}