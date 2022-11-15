using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class CategoryOptionValueApplicationService : BaseApplicationService, ICategoryOptionValueApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public CategoryOptionValueApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddCategoryOptionValue(CategoryOptionValueDto newCategoryOptionValue)
        {
            try
            {
                var categoryOptionValue = Mapper.Map<CategoryOptionValueDto, CategoryOptionValue>(newCategoryOptionValue);
                categoryOptionValue.CreateDate = DateTime.Now;

                await DbContext.CategoryOptionValues.AddAsync(categoryOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "CategoryOptionValue Created Successfully!"
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
        public async Task<ResponseModel> RemoveCategoryOptionValueById(Guid categoryOptionValueId)
        {
            try
            {
                var categoryOptionValue = await DbContext.CategoryOptionValues.FirstOrDefaultAsync(c => c.Id == categoryOptionValueId);
                if (categoryOptionValue is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "CategoryOptionValue Not Found!"
                    };

                DbContext.CategoryOptionValues.Remove(categoryOptionValue);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "CategoryOptionValue Removed Successfully!"
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
        public async Task<ResponseModel> GetAllCategoryOptionValues()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<CategoryOptionValue, CategoryOptionValueDto>(await DbContext.CategoryOptionValues.ToListAsync())
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
        public async Task<ResponseModel> GetCategoryOptionValues(Func<CategoryOptionValue, bool> expression)
        {
            try
            {
                IEnumerable<CategoryOptionValueDto> data = default;
                await Task.Run(() => data = Mapper.MapList<CategoryOptionValue, CategoryOptionValueDto>(DbContext.CategoryOptionValues.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetCategoryOptionValueById(Guid categoryOptionValueId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<CategoryOptionValue, CategoryOptionValueDto>(await DbContext.CategoryOptionValues.FirstOrDefaultAsync(c => c.Id == categoryOptionValueId))
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
        public async Task<ResponseModel> UpdateCategoryOptionValue(CategoryOptionValueDto categoryOptionValue)
        {
            try
            {
                var result = await DbContext.CategoryOptionValues.FirstOrDefaultAsync(c => c.Id == categoryOptionValue.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "CategoryOptionValue Not Found!"
                    };
                result = Mapper.Map<CategoryOptionValueDto, CategoryOptionValue>(categoryOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "CategoryOptionValue Created Successfully!"
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
