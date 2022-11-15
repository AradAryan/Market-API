
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IProductOptionValueApplicationService
    {
        Task<ResponseModel> AddProductOptionValue(ProductOptionValueDto newProductOptionValue);
        Task<ResponseModel> RemoveProductOptionValueById(Guid productOptionValueId);
        Task<ResponseModel> GetAllProductOptionValues();
        Task<ResponseModel> GetProductOptionValues(Func<ProductOptionValue, bool> expression);
        Task<ResponseModel> UpdateProductOptionValue(ProductOptionValueDto productOptionValue);
        Task<ResponseModel> GetProductOptionValueById(Guid productOptionValueId);
    }
}
