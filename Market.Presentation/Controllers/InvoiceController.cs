using Market.Application;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : BaseController<InvoiceController>
    {
        private IInvoiceApplicationService InvoiceApplicationService { get; set; }
        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceApplicationService invoiceApplicationService) : base(logger)
        {
            InvoiceApplicationService = invoiceApplicationService;
        }

        [HttpPost]
        [Route("AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceDto invoice)
        {
            return ReturnResponse(await InvoiceApplicationService.AddInvoice(invoice));
        }

        [HttpDelete]
        [Route("RemoveInvoiceById")]
        public async Task<IActionResult> RemoveInvoiceById(Guid invoiceId)
        {
            return ReturnResponse(await InvoiceApplicationService.RemoveInvoiceById(invoiceId));
        }

        [HttpGet]
        [Route("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            return ReturnResponse(await InvoiceApplicationService.GetAllInvoices());
        }

        [HttpPut]
        [Route("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice(InvoiceDto invoice)
        {
            return ReturnResponse(await InvoiceApplicationService.UpdateInvoice(invoice));
        }

        [HttpPost]
        [Route("GetInvoiceById")]
        public async Task<IActionResult> GetInvoiceById(Guid invoiceId)
        {
            return ReturnResponse(await InvoiceApplicationService.GetInvoiceById(invoiceId));
        }

    }
}
