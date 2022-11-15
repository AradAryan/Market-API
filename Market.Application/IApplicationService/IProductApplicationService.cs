
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IProductApplicationService
    {
        Task<ResponseModel> AddProduct(ProductDto newProduct);
        Task<ResponseModel> RemoveProductById(Guid productId);
        Task<ResponseModel> GetAllProducts();
        Task<ResponseModel> GetProducts(Func<Product, bool> expression);
        Task<ResponseModel> UpdateProduct(ProductDto product);
        Task<ResponseModel> GetProductById(Guid productId);
    }
}
