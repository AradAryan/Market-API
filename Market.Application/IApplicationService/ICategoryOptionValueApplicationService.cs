
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface ICategoryOptionValueApplicationService
    {
        Task<ResponseModel> AddCategoryOptionValue(CategoryOptionValueDto newCategoryOptionValue);
        Task<ResponseModel> RemoveCategoryOptionValueById(Guid categoryOptionValueId);
        Task<ResponseModel> GetAllCategoryOptionValues();
        Task<ResponseModel> GetCategoryOptionValues(Func<CategoryOptionValue, bool> expression);
        Task<ResponseModel> UpdateCategoryOptionValue(CategoryOptionValueDto categoryOptionValue);
        Task<ResponseModel> GetCategoryOptionValueById(Guid categoryOptionValueId);
    }
}
