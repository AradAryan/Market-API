using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class VariantValueApplicationService : BaseApplicationService, IVariantValueApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public VariantValueApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddVariantValue(VariantValueDto newVariantValue)
        {
            try
            {
                var variantValue = Mapper.Map<VariantValueDto, VariantValue>(newVariantValue);
                variantValue.CreateDate = DateTime.Now;

                await DbContext.VariantValues.AddAsync(variantValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "VariantValue Created Successfully!"
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
        public async Task<ResponseModel> RemoveVariantValueById(Guid variantValueId)
        {
            try
            {
                var variantValue = await DbContext.VariantValues.FirstOrDefaultAsync(c => c.Id == variantValueId);
                if (variantValue is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "VariantValue Not Found!"
                    };

                DbContext.VariantValues.Remove(variantValue);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "VariantValue Removed Successfully!"
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
        public async Task<ResponseModel> GetAllVariantValues()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<VariantValue, VariantValueDto>(await DbContext.VariantValues.ToListAsync())
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
        public async Task<ResponseModel> GetVariantValues(Func<VariantValue, bool> expression)
        {
            try
            {
                IEnumerable<VariantValueDto> data = default;
                await Task.Run(() => data = Mapper.MapList<VariantValue, VariantValueDto>(DbContext.VariantValues.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetVariantValueById(Guid variantValueId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<VariantValue, VariantValueDto>(await DbContext.VariantValues.FirstOrDefaultAsync(c => c.Id == variantValueId))
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
        public async Task<ResponseModel> UpdateVariantValue(VariantValueDto variantValue)
        {
            try
            {
                var result = await DbContext.VariantValues.FirstOrDefaultAsync(c => c.Id == variantValue.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "VariantValue Not Found!"
                    };
                result = Mapper.Map<VariantValueDto, VariantValue>(variantValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "VariantValue Created Successfully!"
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
