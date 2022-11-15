using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryOptionValueController : BaseController<CategoryOptionValueController>
    {
        private ICategoryOptionValueApplicationService CategoryOptionValueApplicationService { get; set; }
        public CategoryOptionValueController(ILogger<CategoryOptionValueController> logger, ICategoryOptionValueApplicationService categoryOptionValueApplicationService) : base(logger)
        {
            CategoryOptionValueApplicationService = categoryOptionValueApplicationService;
        }

        [HttpPost]
        [Route("AddCategoryOptionValue")]
        public async Task<IActionResult> AddCategoryOptionValue(CategoryOptionValueDto categoryOptionValue)
        {
            return ReturnResponse(await CategoryOptionValueApplicationService.AddCategoryOptionValue(categoryOptionValue));
        }

        [HttpDelete]
        [Route("RemoveCategoryOptionValueById")]
        public async Task<IActionResult> RemoveCategoryOptionValueById(Guid categoryOptionValueId)
        {
            return ReturnResponse(await CategoryOptionValueApplicationService.RemoveCategoryOptionValueById(categoryOptionValueId));
        }

        [HttpGet]
        [Route("GetAllCategoryOptionValues")]
        public async Task<IActionResult> GetAllCategoryOptionValues()
        {
            return ReturnResponse(await CategoryOptionValueApplicationService.GetAllCategoryOptionValues());
        }

        [HttpPut]
        [Route("UpdateCategoryOptionValue")]
        public async Task<IActionResult> UpdateCategoryOptionValue(CategoryOptionValueDto categoryOptionValue)
        {
            return ReturnResponse(await CategoryOptionValueApplicationService.UpdateCategoryOptionValue(categoryOptionValue));
        }

        [HttpPost]
        [Route("GetCategoryOptionValueById")]
        public async Task<IActionResult> GetCategoryOptionValueById(Guid categoryOptionValueId)
        {
            return ReturnResponse(await CategoryOptionValueApplicationService.GetCategoryOptionValueById(categoryOptionValueId));
        }

    }
}
