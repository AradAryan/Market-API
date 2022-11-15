
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IVariantValueApplicationService
    {
        Task<ResponseModel> AddVariantValue(VariantValueDto newVariantValue);
        Task<ResponseModel> RemoveVariantValueById(Guid variantValueId);
        Task<ResponseModel> GetAllVariantValues();
        Task<ResponseModel> GetVariantValues(Func<VariantValue, bool> expression);
        Task<ResponseModel> UpdateVariantValue(VariantValueDto variantValue);
        Task<ResponseModel> GetVariantValueById(Guid variantValueId);
    }
}
