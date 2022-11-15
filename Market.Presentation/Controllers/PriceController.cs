using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PriceController : BaseController<PriceController>
    {
        private IPriceApplicationService PriceApplicationService { get; set; }
        public PriceController(ILogger<PriceController> logger, IPriceApplicationService priceApplicationService) : base(logger)
        {
            PriceApplicationService = priceApplicationService;
        }

        [HttpPost]
        [Route("AddPrice")]
        public async Task<IActionResult> AddPrice(PriceDto price)
        {
            return ReturnResponse(await PriceApplicationService.AddPrice(price));
        }

        [HttpDelete]
        [Route("RemovePriceById")]
        public async Task<IActionResult> RemovePriceById(Guid priceId)
        {
            return ReturnResponse(await PriceApplicationService.RemovePriceById(priceId));
        }

        [HttpGet]
        [Route("GetAllPrices")]
        public async Task<IActionResult> GetAllPrices()
        {
            return ReturnResponse(await PriceApplicationService.GetAllPrices());
        }

        [HttpPut]
        [Route("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice(PriceDto price)
        {
            return ReturnResponse(await PriceApplicationService.UpdatePrice(price));
        }

        [HttpPost]
        [Route("GetPriceById")]
        public async Task<IActionResult> GetPriceById(Guid priceId)
        {
            return ReturnResponse(await PriceApplicationService.GetPriceById(priceId));
        }

    }
}
