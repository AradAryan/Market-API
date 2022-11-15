using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductPriceController : BaseController<ProductPriceController>
    {
        private IProductPriceApplicationService ProductPriceApplicationService { get; set; }
        public ProductPriceController(ILogger<ProductPriceController> logger, IProductPriceApplicationService productPriceApplicationService) : base(logger)
        {
            ProductPriceApplicationService = productPriceApplicationService;
        }

        [HttpPost]
        [Route("AddProductPrice")]
        public async Task<IActionResult> AddProductPrice(ProductPriceDto productPrice)
        {
            return ReturnResponse(await ProductPriceApplicationService.AddProductPrice(productPrice));
        }

        [HttpDelete]
        [Route("RemoveProductPriceById")]
        public async Task<IActionResult> RemoveProductPriceById(Guid productPriceId)
        {
            return ReturnResponse(await ProductPriceApplicationService.RemoveProductPriceById(productPriceId));
        }

        [HttpGet]
        [Route("GetAllProductPrices")]
        public async Task<IActionResult> GetAllProductPrices()
        {
            return ReturnResponse(await ProductPriceApplicationService.GetAllProductPrices());
        }

        [HttpPut]
        [Route("UpdateProductPrice")]
        public async Task<IActionResult> UpdateProductPrice(ProductPriceDto productPrice)
        {
            return ReturnResponse(await ProductPriceApplicationService.UpdateProductPrice(productPrice));
        }

        [HttpPost]
        [Route("GetProductPriceById")]
        public async Task<IActionResult> GetProductPriceById(Guid productPriceId)
        {
            return ReturnResponse(await ProductPriceApplicationService.GetProductPriceById(productPriceId));
        }

    }
}
