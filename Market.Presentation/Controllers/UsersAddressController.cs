using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersAddressController : BaseController<UsersAddressController>
    {
        private IUsersAddressApplicationService UsersAddressApplicationService { get; set; }
        public UsersAddressController(ILogger<UsersAddressController> logger, IUsersAddressApplicationService usersAddressApplicationService) : base(logger)
        {
            UsersAddressApplicationService = usersAddressApplicationService;
        }

        [HttpPost]
        [Route("AddUsersAddress")]
        public async Task<IActionResult> AddUsersAddress(UsersAddressDto usersAddress)
        {
            return ReturnResponse(await UsersAddressApplicationService.AddUsersAddress(usersAddress));
        }

        [HttpDelete]
        [Route("RemoveUsersAddressById")]
        public async Task<IActionResult> RemoveUsersAddressById(Guid usersAddressId)
        {
            return ReturnResponse(await UsersAddressApplicationService.RemoveUsersAddressById(usersAddressId));
        }

        [HttpGet]
        [Route("GetAllUsersAddresses")]
        public async Task<IActionResult> GetAllUsersAddresses()
        {
            return ReturnResponse(await UsersAddressApplicationService.GetAllUsersAddresses());
        }

        [HttpPut]
        [Route("UpdateUsersAddress")]
        public async Task<IActionResult> UpdateUsersAddress(UsersAddressDto usersAddress)
        {
            return ReturnResponse(await UsersAddressApplicationService.UpdateUsersAddress(usersAddress));
        }

        [HttpPost]
        [Route("GetUsersAddressById")]
        public async Task<IActionResult> GetUsersAddressById(Guid usersAddressId)
        {
            return ReturnResponse(await UsersAddressApplicationService.GetUsersAddressById(usersAddressId));
        }

    }
}
