using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class OrderApplicationService : BaseApplicationService, IOrderApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public OrderApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddOrder(OrderDto newOrder)
        {
            try
            {
                var order = Mapper.Map<OrderDto, Order>(newOrder);
                order.CreateDate = DateTime.Now;

                await DbContext.Orders.AddAsync(order);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Order Created Successfully!"
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
        public async Task<ResponseModel> RemoveOrderById(Guid orderId)
        {
            try
            {
                var order = await DbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId);
                if (order is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Order Not Found!"
                    };

                DbContext.Orders.Remove(order);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Order Removed Successfully!"
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
        public async Task<ResponseModel> GetAllOrders()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Order, OrderDto>(await DbContext.Orders.ToListAsync())
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
        public async Task<ResponseModel> GetOrders(Func<Order, bool> expression)
        {
            try
            {
                IEnumerable<OrderDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Order, OrderDto>(DbContext.Orders.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetOrderById(Guid orderId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Order, OrderDto>(await DbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId))
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
        public async Task<ResponseModel> UpdateOrder(OrderDto order)
        {
            try
            {
                var result = await DbContext.Orders.FirstOrDefaultAsync(c => c.Id == order.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Order Not Found!"
                    };
                result = Mapper.Map<OrderDto, Order>(order);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Order Created Successfully!"
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
