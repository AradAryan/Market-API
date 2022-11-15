using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VariantValueController : BaseController<VariantValueController>
    {
        private IVariantValueApplicationService VariantValueApplicationService { get; set; }
        public VariantValueController(ILogger<VariantValueController> logger, IVariantValueApplicationService variantValueApplicationService) : base(logger)
        {
            VariantValueApplicationService = variantValueApplicationService;
        }

        [HttpPost]
        [Route("AddVariantValue")]
        public async Task<IActionResult> AddVariantValue(VariantValueDto variantValue)
        {
            return ReturnResponse(await VariantValueApplicationService.AddVariantValue(variantValue));
        }

        [HttpDelete]
        [Route("RemoveVariantValueById")]
        public async Task<IActionResult> RemoveVariantValueById(Guid variantValueId)
        {
            return ReturnResponse(await VariantValueApplicationService.RemoveVariantValueById(variantValueId));
        }

        [HttpGet]
        [Route("GetAllVariantValues")]
        public async Task<IActionResult> GetAllVariantValues()
        {
            return ReturnResponse(await VariantValueApplicationService.GetAllVariantValues());
        }

        [HttpPut]
        [Route("UpdateVariantValue")]
        public async Task<IActionResult> UpdateVariantValue(VariantValueDto variantValue)
        {
            return ReturnResponse(await VariantValueApplicationService.UpdateVariantValue(variantValue));
        }

        [HttpPost]
        [Route("GetVariantValueById")]
        public async Task<IActionResult> GetVariantValueById(Guid variantValueId)
        {
            return ReturnResponse(await VariantValueApplicationService.GetVariantValueById(variantValueId));
        }

    }
}
