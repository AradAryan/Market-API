using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionController : BaseController<OptionController>
    {
        private IOptionApplicationService OptionApplicationService { get; set; }
        public OptionController(ILogger<OptionController> logger, IOptionApplicationService optionApplicationService) : base(logger)
        {
            OptionApplicationService = optionApplicationService;
        }

        [HttpPost]
        [Route("AddOption")]
        public async Task<IActionResult> AddOption(OptionDto option)
        {
            return ReturnResponse(await OptionApplicationService.AddOption(option));
        }

        [HttpDelete]
        [Route("RemoveOptionById")]
        public async Task<IActionResult> RemoveOptionById(Guid optionId)
        {
            return ReturnResponse(await OptionApplicationService.RemoveOptionById(optionId));
        }

        [HttpGet]
        [Route("GetAllOptions")]
        public async Task<IActionResult> GetAllOptions()
        {
            return ReturnResponse(await OptionApplicationService.GetAllOptions());
        }

        [HttpPut]
        [Route("UpdateOption")]
        public async Task<IActionResult> UpdateOption(OptionDto option)
        {
            return ReturnResponse(await OptionApplicationService.UpdateOption(option));
        }

        [HttpPost]
        [Route("GetOptionById")]
        public async Task<IActionResult> GetOptionById(Guid optionId)
        {
            return ReturnResponse(await OptionApplicationService.GetOptionById(optionId));
        }

    }
}
