
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IPaymentApplicationService
    {
        Task<ResponseModel> AddPayment(PaymentDto newPayment);
        Task<ResponseModel> RemovePaymentById(Guid paymentId);
        Task<ResponseModel> GetAllPayments();
        Task<ResponseModel> GetPayments(Func<Payment, bool> expression);
        Task<ResponseModel> UpdatePayment(PaymentDto payment);
        Task<ResponseModel> GetPaymentById(Guid paymentId);
    }
}
