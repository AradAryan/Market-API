using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class CategoryOptionApplicationService : BaseApplicationService, ICategoryOptionApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public CategoryOptionApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddCategoryOption(CategoryOptionDto newCategoryOption)
        {
            try
            {
                var categoryOption = Mapper.Map<CategoryOptionDto, CategoryOption>(newCategoryOption);
                categoryOption.CreateDate = DateTime.Now;

                await DbContext.CategoryOptions.AddAsync(categoryOption);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "CategoryOption Created Successfully!"
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
        public async Task<ResponseModel> RemoveCategoryOptionById(Guid categoryOptionId)
        {
            try
            {
                var categoryOption = await DbContext.CategoryOptions.FirstOrDefaultAsync(c => c.Id == categoryOptionId);
                if (categoryOption is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "CategoryOption Not Found!"
                    };

                DbContext.CategoryOptions.Remove(categoryOption);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "CategoryOption Removed Successfully!"
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
        public async Task<ResponseModel> GetAllCategoryOptions()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<CategoryOption, CategoryOptionDto>(await DbContext.CategoryOptions.ToListAsync())
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
        public async Task<ResponseModel> GetCategoryOptions(Func<CategoryOption, bool> expression)
        {
            try
            {
                IEnumerable<CategoryOptionDto> data = default;
                await Task.Run(() => data = Mapper.MapList<CategoryOption, CategoryOptionDto>(DbContext.CategoryOptions.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetCategoryOptionById(Guid categoryOptionId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<CategoryOption, CategoryOptionDto>(await DbContext.CategoryOptions.FirstOrDefaultAsync(c => c.Id == categoryOptionId))
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
        public async Task<ResponseModel> UpdateCategoryOption(CategoryOptionDto categoryOption)
        {
            try
            {
                var result = await DbContext.CategoryOptions.FirstOrDefaultAsync(c => c.Id == categoryOption.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "CategoryOption Not Found!"
                    };
                result = Mapper.Map<CategoryOptionDto, CategoryOption>(categoryOption);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "CategoryOption Created Successfully!"
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
