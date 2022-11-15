using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class TransactionApplicationService : BaseApplicationService, ITransactionApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public TransactionApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddTransaction(TransactionDto newTransaction)
        {
            try
            {
                var transaction = Mapper.Map<TransactionDto, Transaction>(newTransaction);
                transaction.CreateDate = DateTime.Now;

                await DbContext.Transactions.AddAsync(transaction);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Transaction Created Successfully!"
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
        public async Task<ResponseModel> RemoveTransactionById(Guid transactionId)
        {
            try
            {
                var transaction = await DbContext.Transactions.FirstOrDefaultAsync(c => c.Id == transactionId);
                if (transaction is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Transaction Not Found!"
                    };

                DbContext.Transactions.Remove(transaction);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Transaction Removed Successfully!"
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
        public async Task<ResponseModel> GetAllTransactions()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Transaction, TransactionDto>(await DbContext.Transactions.ToListAsync())
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
        public async Task<ResponseModel> GetTransactions(Func<Transaction, bool> expression)
        {
            try
            {
                IEnumerable<TransactionDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Transaction, TransactionDto>(DbContext.Transactions.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetTransactionById(Guid transactionId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Transaction, TransactionDto>(await DbContext.Transactions.FirstOrDefaultAsync(c => c.Id == transactionId))
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
        public async Task<ResponseModel> UpdateTransaction(TransactionDto transaction)
        {
            try
            {
                var result = await DbContext.Transactions.FirstOrDefaultAsync(c => c.Id == transaction.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Transaction Not Found!"
                    };
                result = Mapper.Map<TransactionDto, Transaction>(transaction);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Transaction Created Successfully!"
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
