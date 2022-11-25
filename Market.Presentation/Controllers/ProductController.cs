using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [EnableCors("_MyAllowSubdomainPolicy")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController<ProductController>
    {
        private IProductApplicationService ProductApplicationService { get; set; }
        public ProductController(ILogger<ProductController> logger, IProductApplicationService productApplicationService) : base(logger)
        {
            ProductApplicationService = productApplicationService;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            return ReturnResponse(await ProductApplicationService.AddProduct(product));
        }

        [HttpDelete]
        [Route("RemoveProductById")]
        public async Task<IActionResult> RemoveProductById(Guid productId)
        {
            return ReturnResponse(await ProductApplicationService.RemoveProductById(productId));
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return ReturnResponse(await ProductApplicationService.GetAllProducts());
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            return ReturnResponse(await ProductApplicationService.UpdateProduct(product));
        }

        [HttpPost]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            return ReturnResponse(await ProductApplicationService.GetProductById(productId));
        }

    }
}
