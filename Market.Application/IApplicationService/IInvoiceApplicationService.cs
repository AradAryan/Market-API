
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IInvoiceApplicationService
    {
        Task<ResponseModel> AddInvoice(InvoiceDto newInvoice);
        Task<ResponseModel> RemoveInvoiceById(Guid invoiceId);
        Task<ResponseModel> GetAllInvoices();
        Task<ResponseModel> GetInvoices(Func<Invoice, bool> expression);
        Task<ResponseModel> UpdateInvoice(InvoiceDto invoice);
        Task<ResponseModel> GetInvoiceById(Guid invoiceId);
    }
}
