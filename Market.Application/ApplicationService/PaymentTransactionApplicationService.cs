using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class PaymentTransactionApplicationService : BaseApplicationService, IPaymentTransactionApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public PaymentTransactionApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddPaymentTransaction(PaymentTransactionDto newPaymentTransaction)
        {
            try
            {
                var paymentTransaction = Mapper.Map<PaymentTransactionDto, PaymentTransaction>(newPaymentTransaction);
                paymentTransaction.CreateDate = DateTime.Now;

                await DbContext.PaymentTransactions.AddAsync(paymentTransaction);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "PaymentTransaction Created Successfully!"
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
        public async Task<ResponseModel> RemovePaymentTransactionById(Guid paymentTransactionId)
        {
            try
            {
                var paymentTransaction = await DbContext.PaymentTransactions.FirstOrDefaultAsync(c => c.Id == paymentTransactionId);
                if (paymentTransaction is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "PaymentTransaction Not Found!"
                    };

                DbContext.PaymentTransactions.Remove(paymentTransaction);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "PaymentTransaction Removed Successfully!"
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
        public async Task<ResponseModel> GetAllPaymentTransactions()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<PaymentTransaction, PaymentTransactionDto>(await DbContext.PaymentTransactions.ToListAsync())
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
        public async Task<ResponseModel> GetPaymentTransactions(Func<PaymentTransaction, bool> expression)
        {
            try
            {
                IEnumerable<PaymentTransactionDto> data = default;
                await Task.Run(() => data = Mapper.MapList<PaymentTransaction, PaymentTransactionDto>(DbContext.PaymentTransactions.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetPaymentTransactionById(Guid paymentTransactionId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<PaymentTransaction, PaymentTransactionDto>(await DbContext.PaymentTransactions.FirstOrDefaultAsync(c => c.Id == paymentTransactionId))
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
        public async Task<ResponseModel> UpdatePaymentTransaction(PaymentTransactionDto paymentTransaction)
        {
            try
            {
                var result = await DbContext.PaymentTransactions.FirstOrDefaultAsync(c => c.Id == paymentTransaction.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "PaymentTransaction Not Found!"
                    };
                result = Mapper.Map<PaymentTransactionDto, PaymentTransaction>(paymentTransaction);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "PaymentTransaction Created Successfully!"
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
