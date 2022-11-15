using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : BaseController<TransactionController>
    {
        private ITransactionApplicationService TransactionApplicationService { get; set; }
        public TransactionController(ILogger<TransactionController> logger, ITransactionApplicationService transactionApplicationService) : base(logger)
        {
            TransactionApplicationService = transactionApplicationService;
        }

        [HttpPost]
        [Route("AddTransaction")]
        public async Task<IActionResult> AddTransaction(TransactionDto transaction)
        {
            return ReturnResponse(await TransactionApplicationService.AddTransaction(transaction));
        }

        [HttpDelete]
        [Route("RemoveTransactionById")]
        public async Task<IActionResult> RemoveTransactionById(Guid transactionId)
        {
            return ReturnResponse(await TransactionApplicationService.RemoveTransactionById(transactionId));
        }

        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            return ReturnResponse(await TransactionApplicationService.GetAllTransactions());
        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction(TransactionDto transaction)
        {
            return ReturnResponse(await TransactionApplicationService.UpdateTransaction(transaction));
        }

        [HttpPost]
        [Route("GetTransactionById")]
        public async Task<IActionResult> GetTransactionById(Guid transactionId)
        {
            return ReturnResponse(await TransactionApplicationService.GetTransactionById(transactionId));
        }

    }
}
