
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IShopProductOptionValueApplicationService
    {
        Task<ResponseModel> AddShopProductOptionValue(ShopProductOptionValueDto newShopProductOptionValue);
        Task<ResponseModel> RemoveShopProductOptionValueById(Guid shopProductOptionValueId);
        Task<ResponseModel> GetAllShopProductOptionValues();
        Task<ResponseModel> GetShopProductOptionValues(Func<ShopProductOptionValue, bool> expression);
        Task<ResponseModel> UpdateShopProductOptionValue(ShopProductOptionValueDto shopProductOptionValue);
        Task<ResponseModel> GetShopProductOptionValueById(Guid shopProductOptionValueId);
    }
}
