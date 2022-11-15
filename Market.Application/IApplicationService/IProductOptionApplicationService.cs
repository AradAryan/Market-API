
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IProductOptionApplicationService
    {
        Task<ResponseModel> AddProductOption(ProductOptionDto newProductOption);
        Task<ResponseModel> RemoveProductOptionById(Guid productOptionId);
        Task<ResponseModel> GetAllProductOptions();
        Task<ResponseModel> GetProductOptions(Func<ProductOption, bool> expression);
        Task<ResponseModel> UpdateProductOption(ProductOptionDto productOption);
        Task<ResponseModel> GetProductOptionById(Guid productOptionId);
    }
}
