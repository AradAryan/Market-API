
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface ICategoryOptionApplicationService
    {
        Task<ResponseModel> AddCategoryOption(CategoryOptionDto newCategoryOption);
        Task<ResponseModel> RemoveCategoryOptionById(Guid categoryOptionId);
        Task<ResponseModel> GetAllCategoryOptions();
        Task<ResponseModel> GetCategoryOptions(Func<CategoryOption, bool> expression);
        Task<ResponseModel> UpdateCategoryOption(CategoryOptionDto categoryOption);
        Task<ResponseModel> GetCategoryOptionById(Guid categoryOptionId);
    }
}
