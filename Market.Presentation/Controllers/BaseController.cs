using Market.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        public ILogger<T> Logger { get; set; }

        public BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }

        internal IActionResult ReturnResponse(bool succeed, string? error = default, object? data = default)
        {
            ResponseModel? response = new()
            {
                Succeed = succeed,
                Message = error,
                Data = data,
            };
            return succeed ? Ok(response) : BadRequest(response);
        }

        internal IActionResult ReturnResponse(ResponseModel? response)
        {
            return response.Succeed ? Ok(response) : BadRequest(response);
        }
    }
}
