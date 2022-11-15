
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IPaymentTransactionApplicationService
    {
        Task<ResponseModel> AddPaymentTransaction(PaymentTransactionDto newPaymentTransaction);
        Task<ResponseModel> RemovePaymentTransactionById(Guid paymentTransactionId);
        Task<ResponseModel> GetAllPaymentTransactions();
        Task<ResponseModel> GetPaymentTransactions(Func<PaymentTransaction, bool> expression);
        Task<ResponseModel> UpdatePaymentTransaction(PaymentTransactionDto paymentTransaction);
        Task<ResponseModel> GetPaymentTransactionById(Guid paymentTransactionId);
    }
}
