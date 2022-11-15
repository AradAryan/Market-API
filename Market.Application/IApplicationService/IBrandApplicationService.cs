
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IBrandApplicationService
    {
        Task<ResponseModel> AddBrand(BrandDto newBrand);
        Task<ResponseModel> RemoveBrandById(Guid brandId);
        Task<ResponseModel> GetAllBrands();
        Task<ResponseModel> GetBrands(Func<Brand, bool> expression);
        Task<ResponseModel> UpdateBrand(BrandDto brand);
        Task<ResponseModel> GetBrandById(Guid brandId);
    }
}
