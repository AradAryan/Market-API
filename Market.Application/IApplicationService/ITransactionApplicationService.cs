
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface ITransactionApplicationService
    {
        Task<ResponseModel> AddTransaction(TransactionDto newTransaction);
        Task<ResponseModel> RemoveTransactionById(Guid transactionId);
        Task<ResponseModel> GetAllTransactions();
        Task<ResponseModel> GetTransactions(Func<Transaction, bool> expression);
        Task<ResponseModel> UpdateTransaction(TransactionDto transaction);
        Task<ResponseModel> GetTransactionById(Guid transactionId);
    }
}
