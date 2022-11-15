using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShopController : BaseController<ShopController>
    {
        private IShopApplicationService ShopApplicationService { get; set; }
        public ShopController(ILogger<ShopController> logger, IShopApplicationService shopApplicationService) : base(logger)
        {
            ShopApplicationService = shopApplicationService;
        }

        [HttpPost]
        [Route("AddShop")]
        public async Task<IActionResult> AddShop(ShopDto shop)
        {
            return ReturnResponse(await ShopApplicationService.AddShop(shop));
        }

        [HttpDelete]
        [Route("RemoveShopById")]
        public async Task<IActionResult> RemoveShopById(Guid shopId)
        {
            return ReturnResponse(await ShopApplicationService.RemoveShopById(shopId));
        }

        [HttpGet]
        [Route("GetAllShops")]
        public async Task<IActionResult> GetAllShops()
        {
            return ReturnResponse(await ShopApplicationService.GetAllShops());
        }

        [HttpPut]
        [Route("UpdateShop")]
        public async Task<IActionResult> UpdateShop(ShopDto shop)
        {
            return ReturnResponse(await ShopApplicationService.UpdateShop(shop));
        }

        [HttpPost]
        [Route("GetShopById")]
        public async Task<IActionResult> GetShopById(Guid shopId)
        {
            return ReturnResponse(await ShopApplicationService.GetShopById(shopId));
        }

    }
}
