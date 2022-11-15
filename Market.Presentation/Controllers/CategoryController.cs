using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : BaseController<CategoryController>
    {
        private ICategoryApplicationService CategoryApplicationService { get; set; }
        public CategoryController(ILogger<CategoryController> logger, ICategoryApplicationService categoryApplicationService) : base(logger)
        {
            CategoryApplicationService = categoryApplicationService;
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            return ReturnResponse(await CategoryApplicationService.AddCategory(category));
        }

        [HttpDelete]
        [Route("RemoveCategoryById")]
        public async Task<IActionResult> RemoveCategoryById(Guid categoryId)
        {
            return ReturnResponse(await CategoryApplicationService.RemoveCategoryById(categoryId));
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return ReturnResponse(await CategoryApplicationService.GetAllCategory());
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            return ReturnResponse(await CategoryApplicationService.UpdateCategory(category));
        }

        [HttpPost]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId)
        {
            return ReturnResponse(await CategoryApplicationService.GetCategoryById(categoryId));
        }

    }
}
