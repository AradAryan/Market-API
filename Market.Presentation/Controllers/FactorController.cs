using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FactorController : BaseController<FactorController>
    {
        private IFactorApplicationService FactorApplicationService { get; set; }
        public FactorController(ILogger<FactorController> logger, IFactorApplicationService factorApplicationService) : base(logger)
        {
            FactorApplicationService = factorApplicationService;
        }

        [HttpPost]
        [Route("AddFactor")]
        public async Task<IActionResult> AddFactor(FactorDto factor)
        {
            return ReturnResponse(await FactorApplicationService.AddFactor(factor));
        }

        [HttpDelete]
        [Route("RemoveFactorById")]
        public async Task<IActionResult> RemoveFactorById(Guid factorId)
        {
            return ReturnResponse(await FactorApplicationService.RemoveFactorById(factorId));
        }

        [HttpGet]
        [Route("GetAllFactors")]
        public async Task<IActionResult> GetAllFactors()
        {
            return ReturnResponse(await FactorApplicationService.GetAllFactors());
        }

        [HttpPut]
        [Route("UpdateFactor")]
        public async Task<IActionResult> UpdateFactor(FactorDto factor)
        {
            return ReturnResponse(await FactorApplicationService.UpdateFactor(factor));
        }

        [HttpPost]
        [Route("GetFactorById")]
        public async Task<IActionResult> GetFactorById(Guid factorId)
        {
            return ReturnResponse(await FactorApplicationService.GetFactorById(factorId));
        }

    }
}
