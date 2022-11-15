
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IPriceApplicationService
    {
        Task<ResponseModel> AddPrice(PriceDto newPrice);
        Task<ResponseModel> RemovePriceById(Guid priceId);
        Task<ResponseModel> GetAllPrices();
        Task<ResponseModel> GetPrices(Func<Price, bool> expression);
        Task<ResponseModel> UpdatePrice(PriceDto price);
        Task<ResponseModel> GetPriceById(Guid priceId);
    }
}
