using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShopProductOptionValueController : BaseController<ShopProductOptionValueController>
    {
        private IShopProductOptionValueApplicationService ShopProductOptionValueApplicationService { get; set; }
        public ShopProductOptionValueController(ILogger<ShopProductOptionValueController> logger, IShopProductOptionValueApplicationService shopProductOptionValueApplicationService) : base(logger)
        {
            ShopProductOptionValueApplicationService = shopProductOptionValueApplicationService;
        }

        [HttpPost]
        [Route("AddShopProductOptionValue")]
        public async Task<IActionResult> AddShopProductOptionValue(ShopProductOptionValueDto shopProductOptionValue)
        {
            return ReturnResponse(await ShopProductOptionValueApplicationService.AddShopProductOptionValue(shopProductOptionValue));
        }

        [HttpDelete]
        [Route("RemoveShopProductOptionValueById")]
        public async Task<IActionResult> RemoveShopProductOptionValueById(Guid shopProductOptionValueId)
        {
            return ReturnResponse(await ShopProductOptionValueApplicationService.RemoveShopProductOptionValueById(shopProductOptionValueId));
        }

        [HttpGet]
        [Route("GetAllShopProductOptionValues")]
        public async Task<IActionResult> GetAllShopProductOptionValues()
        {
            return ReturnResponse(await ShopProductOptionValueApplicationService.GetAllShopProductOptionValues());
        }

        [HttpPut]
        [Route("UpdateShopProductOptionValue")]
        public async Task<IActionResult> UpdateShopProductOptionValue(ShopProductOptionValueDto shopProductOptionValue)
        {
            return ReturnResponse(await ShopProductOptionValueApplicationService.UpdateShopProductOptionValue(shopProductOptionValue));
        }

        [HttpPost]
        [Route("GetShopProductOptionValueById")]
        public async Task<IActionResult> GetShopProductOptionValueById(Guid shopProductOptionValueId)
        {
            return ReturnResponse(await ShopProductOptionValueApplicationService.GetShopProductOptionValueById(shopProductOptionValueId));
        }

    }
}
