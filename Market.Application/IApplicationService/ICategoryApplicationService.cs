
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface ICategoryApplicationService
    {
        Task<ResponseModel> AddCategory(CategoryDto newCategory);
        Task<ResponseModel> RemoveCategoryById(Guid categoryId);
        Task<ResponseModel> GetAllCategory();
        Task<ResponseModel> GetCategory(Func<Category, bool> expression);
        Task<ResponseModel> UpdateCategory(CategoryDto category);
        Task<ResponseModel> GetCategoryById(Guid categoryId);
    }
}
