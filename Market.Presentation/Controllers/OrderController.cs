using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseController<OrderController>
    {
        private IOrderApplicationService OrderApplicationService { get; set; }
        public OrderController(ILogger<OrderController> logger, IOrderApplicationService orderApplicationService) : base(logger)
        {
            OrderApplicationService = orderApplicationService;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDto order)
        {
            return ReturnResponse(await OrderApplicationService.AddOrder(order));
        }

        [HttpDelete]
        [Route("RemoveOrderById")]
        public async Task<IActionResult> RemoveOrderById(Guid orderId)
        {
            return ReturnResponse(await OrderApplicationService.RemoveOrderById(orderId));
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return ReturnResponse(await OrderApplicationService.GetAllOrders());
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDto order)
        {
            return ReturnResponse(await OrderApplicationService.UpdateOrder(order));
        }

        [HttpPost]
        [Route("GetOrderById")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            return ReturnResponse(await OrderApplicationService.GetOrderById(orderId));
        }

    }
}
