
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IOrderApplicationService
    {
        Task<ResponseModel> AddOrder(OrderDto newOrder);
        Task<ResponseModel> RemoveOrderById(Guid orderId);
        Task<ResponseModel> GetAllOrders();
        Task<ResponseModel> GetOrders(Func<Order, bool> expression);
        Task<ResponseModel> UpdateOrder(OrderDto order);
        Task<ResponseModel> GetOrderById(Guid orderId);
    }
}
