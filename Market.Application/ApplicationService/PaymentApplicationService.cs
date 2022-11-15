using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class PaymentApplicationService : BaseApplicationService, IPaymentApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public PaymentApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddPayment(PaymentDto newPayment)
        {
            try
            {
                var payment = Mapper.Map<PaymentDto, Payment>(newPayment);
                payment.CreateDate = DateTime.Now;

                await DbContext.Payments.AddAsync(payment);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Payment Created Successfully!"
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
        public async Task<ResponseModel> RemovePaymentById(Guid paymentId)
        {
            try
            {
                var payment = await DbContext.Payments.FirstOrDefaultAsync(c => c.Id == paymentId);
                if (payment is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Payment Not Found!"
                    };

                DbContext.Payments.Remove(payment);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Payment Removed Successfully!"
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
        public async Task<ResponseModel> GetAllPayments()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Payment, PaymentDto>(await DbContext.Payments.ToListAsync())
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
        public async Task<ResponseModel> GetPayments(Func<Payment, bool> expression)
        {
            try
            {
                IEnumerable<PaymentDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Payment, PaymentDto>(DbContext.Payments.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetPaymentById(Guid paymentId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Payment, PaymentDto>(await DbContext.Payments.FirstOrDefaultAsync(c => c.Id == paymentId))
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
        public async Task<ResponseModel> UpdatePayment(PaymentDto payment)
        {
            try
            {
                var result = await DbContext.Payments.FirstOrDefaultAsync(c => c.Id == payment.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Payment Not Found!"
                    };
                result = Mapper.Map<PaymentDto, Payment>(payment);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Payment Created Successfully!"
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
