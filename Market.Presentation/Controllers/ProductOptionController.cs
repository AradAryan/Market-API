using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductOptionController : BaseController<ProductOptionController>
    {
        private IProductOptionApplicationService ProductOptionApplicationService { get; set; }
        public ProductOptionController(ILogger<ProductOptionController> logger, IProductOptionApplicationService productOptionApplicationService) : base(logger)
        {
            ProductOptionApplicationService = productOptionApplicationService;
        }

        [HttpPost]
        [Route("AddProductOption")]
        public async Task<IActionResult> AddProductOption(ProductOptionDto productOption)
        {
            return ReturnResponse(await ProductOptionApplicationService.AddProductOption(productOption));
        }

        [HttpDelete]
        [Route("RemoveProductOptionById")]
        public async Task<IActionResult> RemoveProductOptionById(Guid productOptionId)
        {
            return ReturnResponse(await ProductOptionApplicationService.RemoveProductOptionById(productOptionId));
        }

        [HttpGet]
        [Route("GetAllProductOptions")]
        public async Task<IActionResult> GetAllProductOptions()
        {
            return ReturnResponse(await ProductOptionApplicationService.GetAllProductOptions());
        }

        [HttpPut]
        [Route("UpdateProductOption")]
        public async Task<IActionResult> UpdateProductOption(ProductOptionDto productOption)
        {
            return ReturnResponse(await ProductOptionApplicationService.UpdateProductOption(productOption));
        }

        [HttpPost]
        [Route("GetProductOptionById")]
        public async Task<IActionResult> GetProductOptionById(Guid productOptionId)
        {
            return ReturnResponse(await ProductOptionApplicationService.GetProductOptionById(productOptionId));
        }

    }
}
