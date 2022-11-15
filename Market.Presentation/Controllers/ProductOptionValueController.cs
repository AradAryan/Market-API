using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductOptionValueController : BaseController<ProductOptionValueController>
    {
        private IProductOptionValueApplicationService ProductOptionValueApplicationService { get; set; }
        public ProductOptionValueController(ILogger<ProductOptionValueController> logger, IProductOptionValueApplicationService productOptionValueApplicationService) : base(logger)
        {
            ProductOptionValueApplicationService = productOptionValueApplicationService;
        }

        [HttpPost]
        [Route("AddProductOptionValue")]
        public async Task<IActionResult> AddProductOptionValue(ProductOptionValueDto productOptionValue)
        {
            return ReturnResponse(await ProductOptionValueApplicationService.AddProductOptionValue(productOptionValue));
        }

        [HttpDelete]
        [Route("RemoveProductOptionValueById")]
        public async Task<IActionResult> RemoveProductOptionValueById(Guid productOptionValueId)
        {
            return ReturnResponse(await ProductOptionValueApplicationService.RemoveProductOptionValueById(productOptionValueId));
        }

        [HttpGet]
        [Route("GetAllProductOptionValues")]
        public async Task<IActionResult> GetAllProductOptionValues()
        {
            return ReturnResponse(await ProductOptionValueApplicationService.GetAllProductOptionValues());
        }

        [HttpPut]
        [Route("UpdateProductOptionValue")]
        public async Task<IActionResult> UpdateProductOptionValue(ProductOptionValueDto productOptionValue)
        {
            return ReturnResponse(await ProductOptionValueApplicationService.UpdateProductOptionValue(productOptionValue));
        }

        [HttpPost]
        [Route("GetProductOptionValueById")]
        public async Task<IActionResult> GetProductOptionValueById(Guid productOptionValueId)
        {
            return ReturnResponse(await ProductOptionValueApplicationService.GetProductOptionValueById(productOptionValueId));
        }

    }
}
