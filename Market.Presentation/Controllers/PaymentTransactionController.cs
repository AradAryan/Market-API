using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentTransactionController : BaseController<PaymentTransactionController>
    {
        private IPaymentTransactionApplicationService PaymentTransactionApplicationService { get; set; }
        public PaymentTransactionController(ILogger<PaymentTransactionController> logger, IPaymentTransactionApplicationService paymentTransactionApplicationService) : base(logger)
        {
            PaymentTransactionApplicationService = paymentTransactionApplicationService;
        }

        [HttpPost]
        [Route("AddPaymentTransaction")]
        public async Task<IActionResult> AddPaymentTransaction(PaymentTransactionDto paymentTransaction)
        {
            return ReturnResponse(await PaymentTransactionApplicationService.AddPaymentTransaction(paymentTransaction));
        }

        [HttpDelete]
        [Route("RemovePaymentTransactionById")]
        public async Task<IActionResult> RemovePaymentTransactionById(Guid paymentTransactionId)
        {
            return ReturnResponse(await PaymentTransactionApplicationService.RemovePaymentTransactionById(paymentTransactionId));
        }

        [HttpGet]
        [Route("GetAllPaymentTransactions")]
        public async Task<IActionResult> GetAllPaymentTransactions()
        {
            return ReturnResponse(await PaymentTransactionApplicationService.GetAllPaymentTransactions());
        }

        [HttpPut]
        [Route("UpdatePaymentTransaction")]
        public async Task<IActionResult> UpdatePaymentTransaction(PaymentTransactionDto paymentTransaction)
        {
            return ReturnResponse(await PaymentTransactionApplicationService.UpdatePaymentTransaction(paymentTransaction));
        }

        [HttpPost]
        [Route("GetPaymentTransactionById")]
        public async Task<IActionResult> GetPaymentTransactionById(Guid paymentTransactionId)
        {
            return ReturnResponse(await PaymentTransactionApplicationService.GetPaymentTransactionById(paymentTransactionId));
        }

    }
}
