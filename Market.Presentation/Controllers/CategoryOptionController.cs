using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryOptionController : BaseController<CategoryOptionController>
    {
        private ICategoryOptionApplicationService CategoryOptionApplicationService { get; set; }
        public CategoryOptionController(ILogger<CategoryOptionController> logger, ICategoryOptionApplicationService categoryOptionApplicationService) : base(logger)
        {
            CategoryOptionApplicationService = categoryOptionApplicationService;
        }

        [HttpPost]
        [Route("AddCategoryOption")]
        public async Task<IActionResult> AddCategoryOption(CategoryOptionDto categoryOption)
        {
            return ReturnResponse(await CategoryOptionApplicationService.AddCategoryOption(categoryOption));
        }

        [HttpDelete]
        [Route("RemoveCategoryOptionById")]
        public async Task<IActionResult> RemoveCategoryOptionById(Guid categoryOptionId)
        {
            return ReturnResponse(await CategoryOptionApplicationService.RemoveCategoryOptionById(categoryOptionId));
        }

        [HttpGet]
        [Route("GetAllCategoryOptions")]
        public async Task<IActionResult> GetAllCategoryOptions()
        {
            return ReturnResponse(await CategoryOptionApplicationService.GetAllCategoryOptions());
        }

        [HttpPut]
        [Route("UpdateCategoryOption")]
        public async Task<IActionResult> UpdateCategoryOption(CategoryOptionDto categoryOption)
        {
            return ReturnResponse(await CategoryOptionApplicationService.UpdateCategoryOption(categoryOption));
        }

        [HttpPost]
        [Route("GetCategoryOptionById")]
        public async Task<IActionResult> GetCategoryOptionById(Guid categoryOptionId)
        {
            return ReturnResponse(await CategoryOptionApplicationService.GetCategoryOptionById(categoryOptionId));
        }

    }
}
