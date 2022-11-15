using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionValueController : BaseController<OptionValueController>
    {
        private IOptionValueApplicationService OptionValueApplicationService { get; set; }
        public OptionValueController(ILogger<OptionValueController> logger, IOptionValueApplicationService optionValueApplicationService) : base(logger)
        {
            OptionValueApplicationService = optionValueApplicationService;
        }

        [HttpPost]
        [Route("AddOptionValue")]
        public async Task<IActionResult> AddOptionValue(OptionValueDto optionValue)
        {
            return ReturnResponse(await OptionValueApplicationService.AddOptionValue(optionValue));
        }

        [HttpDelete]
        [Route("RemoveOptionValueById")]
        public async Task<IActionResult> RemoveOptionValueById(Guid optionValueId)
        {
            return ReturnResponse(await OptionValueApplicationService.RemoveOptionValueById(optionValueId));
        }

        [HttpGet]
        [Route("GetAllOptionValues")]
        public async Task<IActionResult> GetAllOptionValues()
        {
            return ReturnResponse(await OptionValueApplicationService.GetAllOptionValues());
        }

        [HttpPut]
        [Route("UpdateOptionValue")]
        public async Task<IActionResult> UpdateOptionValue(OptionValueDto optionValue)
        {
            return ReturnResponse(await OptionValueApplicationService.UpdateOptionValue(optionValue));
        }

        [HttpPost]
        [Route("GetOptionValueById")]
        public async Task<IActionResult> GetOptionValueById(Guid optionValueId)
        {
            return ReturnResponse(await OptionValueApplicationService.GetOptionValueById(optionValueId));
        }

    }
}
