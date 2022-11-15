using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : BaseController<AddressController>
    {
        private IAddressApplicationService AddressApplicationService { get; set; }
        public AddressController(ILogger<AddressController> logger, IAddressApplicationService addressApplicationService) : base(logger)
        {
            AddressApplicationService = addressApplicationService;
        }

        [HttpPost]
        [Route("AddAddress")]
        public async Task<IActionResult> AddAddress(AddressDto address)
        {
            return ReturnResponse(await AddressApplicationService.AddAddress(address));
        }

        [HttpDelete]
        [Route("RemoveAddressById")]
        public async Task<IActionResult> RemoveAddressById(Guid addressId)
        {
            return ReturnResponse(await AddressApplicationService.RemoveAddressById(addressId));
        }

        [HttpGet]
        [Route("GetAllAddresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            return ReturnResponse(await AddressApplicationService.GetAllAddresses());
        }

        [HttpPut]
        [Route("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(AddressDto address)
        {
            return ReturnResponse(await AddressApplicationService.UpdateAddress(address));
        }

        [HttpPost]
        [Route("GetAddressById")]
        public async Task<IActionResult> GetAddressById(Guid addressId)
        {
            return ReturnResponse(await AddressApplicationService.GetAddressById(addressId));
        }

    }
}
