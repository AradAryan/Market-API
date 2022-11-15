
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IShopApplicationService
    {
        Task<ResponseModel> AddShop(ShopDto newShop);
        Task<ResponseModel> RemoveShopById(Guid shopId);
        Task<ResponseModel> GetAllShops();
        Task<ResponseModel> GetShops(Func<Shop, bool> expression);
        Task<ResponseModel> UpdateShop(ShopDto shop);
        Task<ResponseModel> GetShopById(Guid shopId);
    }
}
