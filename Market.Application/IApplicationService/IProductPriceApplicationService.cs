
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IProductPriceApplicationService
    {
        Task<ResponseModel> AddProductPrice(ProductPriceDto newProductPrice);
        Task<ResponseModel> RemoveProductPriceById(Guid productPriceId);
        Task<ResponseModel> GetAllProductPrices();
        Task<ResponseModel> GetProductPrices(Func<ProductPrice, bool> expression);
        Task<ResponseModel> UpdateProductPrice(ProductPriceDto productPrice);
        Task<ResponseModel> GetProductPriceById(Guid productPriceId);
    }
}
