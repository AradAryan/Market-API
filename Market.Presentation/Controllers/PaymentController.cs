using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : BaseController<PaymentController>
    {
        private IPaymentApplicationService PaymentApplicationService { get; set; }
        public PaymentController(ILogger<PaymentController> logger, IPaymentApplicationService paymentApplicationService) : base(logger)
        {
            PaymentApplicationService = paymentApplicationService;
        }

        [HttpPost]
        [Route("AddPayment")]
        public async Task<IActionResult> AddPayment(PaymentDto payment)
        {
            return ReturnResponse(await PaymentApplicationService.AddPayment(payment));
        }

        [HttpDelete]
        [Route("RemovePaymentById")]
        public async Task<IActionResult> RemovePaymentById(Guid paymentId)
        {
            return ReturnResponse(await PaymentApplicationService.RemovePaymentById(paymentId));
        }

        [HttpGet]
        [Route("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            return ReturnResponse(await PaymentApplicationService.GetAllPayments());
        }

        [HttpPut]
        [Route("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(PaymentDto payment)
        {
            return ReturnResponse(await PaymentApplicationService.UpdatePayment(payment));
        }

        [HttpPost]
        [Route("GetPaymentById")]
        public async Task<IActionResult> GetPaymentById(Guid paymentId)
        {
            return ReturnResponse(await PaymentApplicationService.GetPaymentById(paymentId));
        }

    }
}
