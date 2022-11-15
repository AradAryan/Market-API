using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class InvoiceApplicationService : BaseApplicationService, IInvoiceApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public InvoiceApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddInvoice(InvoiceDto newInvoice)
        {
            try
            {
                var invoice = Mapper.Map<InvoiceDto, Invoice>(newInvoice);
                invoice.CreateDate = DateTime.Now;

                await DbContext.Invoices.AddAsync(invoice);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Invoice Created Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> RemoveInvoiceById(Guid invoiceId)
        {
            try
            {
                var invoice = await DbContext.Invoices.FirstOrDefaultAsync(c => c.Id == invoiceId);
                if (invoice is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Invoice Not Found!"
                    };

                DbContext.Invoices.Remove(invoice);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Invoice Removed Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetAllInvoices()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Invoice, InvoiceDto>(await DbContext.Invoices.ToListAsync())
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetInvoices(Func<Invoice, bool> expression)
        {
            try
            {
                IEnumerable<InvoiceDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Invoice, InvoiceDto>(DbContext.Invoices.Where(expression).ToList()));
                return new()
                {
                    Succeed = true,
                    Data = data,
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetInvoiceById(Guid invoiceId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Invoice, InvoiceDto>(await DbContext.Invoices.FirstOrDefaultAsync(c => c.Id == invoiceId))
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> UpdateInvoice(InvoiceDto invoice)
        {
            try
            {
                var result = await DbContext.Invoices.FirstOrDefaultAsync(c => c.Id == invoice.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Invoice Not Found!"
                    };
                result = Mapper.Map<InvoiceDto, Invoice>(invoice);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Invoice Created Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
