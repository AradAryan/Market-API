using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : BaseController<BrandController>
    {
        private IBrandApplicationService BrandApplicationService { get; set; }
        public BrandController(ILogger<BrandController> logger, IBrandApplicationService brandApplicationService) : base(logger)
        {
            BrandApplicationService = brandApplicationService;
        }

        [HttpPost]
        [Route("AddBrand")]
        public async Task<IActionResult> AddBrand(BrandDto brand)
        {
            return ReturnResponse(await BrandApplicationService.AddBrand(brand));
        }

        [HttpDelete]
        [Route("RemoveBrandById")]
        public async Task<IActionResult> RemoveBrandById(Guid brandId)
        {
            return ReturnResponse(await BrandApplicationService.RemoveBrandById(brandId));
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            return ReturnResponse(await BrandApplicationService.GetAllBrands());
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(BrandDto brand)
        {
            return ReturnResponse(await BrandApplicationService.UpdateBrand(brand));
        }

        [HttpPost]
        [Route("GetBrandById")]
        public async Task<IActionResult> GetBrandById(Guid brandId)
        {
            return ReturnResponse(await BrandApplicationService.GetBrandById(brandId));
        }

    }
}
