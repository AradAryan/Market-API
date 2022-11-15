using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class CategoryApplicationService : BaseApplicationService, ICategoryApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public CategoryApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddCategory(CategoryDto newCategory)
        {
            try
            {
                var category = Mapper.Map<CategoryDto, Category>(newCategory);
                category.CreateDate = DateTime.Now;

                await DbContext.Category.AddAsync(category);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Category Created Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> RemoveCategoryById(Guid categoryId)
        {
            try
            {
                var category = await DbContext.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
                if (category is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Category Not Found!"
                    };

                DbContext.Category.Remove(category);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Category Removed Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetAllCategory()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Category, CategoryDto>(await DbContext.Category.ToListAsync())
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetCategory(Func<Category, bool> expression)
        {
            try
            {
                IEnumerable<CategoryDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Category, CategoryDto>(DbContext.Category.Where(expression).ToList()));
                return new()
                {
                    Succeed = true,
                    Data = data,
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> GetCategoryById(Guid categoryId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Category, CategoryDto>(await DbContext.Category.FirstOrDefaultAsync(c => c.Id == categoryId))
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseModel> UpdateCategory(CategoryDto category)
        {
            try
            {
                var result = await DbContext.Category.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Category Not Found!"
                    };
                result = Mapper.Map<CategoryDto, Category>(category);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Category Created Successfully!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Succeed = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
