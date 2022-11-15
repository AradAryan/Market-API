using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class OptionValueApplicationService : BaseApplicationService, IOptionValueApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public OptionValueApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddOptionValue(OptionValueDto newOptionValue)
        {
            try
            {
                var optionValue = Mapper.Map<OptionValueDto, OptionValue>(newOptionValue);
                optionValue.CreateDate = DateTime.Now;

                await DbContext.OptionValues.AddAsync(optionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "OptionValue Created Successfully!"
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
        public async Task<ResponseModel> RemoveOptionValueById(Guid optionValueId)
        {
            try
            {
                var optionValue = await DbContext.OptionValues.FirstOrDefaultAsync(c => c.Id == optionValueId);
                if (optionValue is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "OptionValue Not Found!"
                    };

                DbContext.OptionValues.Remove(optionValue);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "OptionValue Removed Successfully!"
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
        public async Task<ResponseModel> GetAllOptionValues()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<OptionValue, OptionValueDto>(await DbContext.OptionValues.ToListAsync())
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
        public async Task<ResponseModel> GetOptionValues(Func<OptionValue, bool> expression)
        {
            try
            {
                IEnumerable<OptionValueDto> data = default;
                await Task.Run(() => data = Mapper.MapList<OptionValue, OptionValueDto>(DbContext.OptionValues.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetOptionValueById(Guid optionValueId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<OptionValue, OptionValueDto>(await DbContext.OptionValues.FirstOrDefaultAsync(c => c.Id == optionValueId))
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
        public async Task<ResponseModel> UpdateOptionValue(OptionValueDto optionValue)
        {
            try
            {
                var result = await DbContext.OptionValues.FirstOrDefaultAsync(c => c.Id == optionValue.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "OptionValue Not Found!"
                    };
                result = Mapper.Map<OptionValueDto, OptionValue>(optionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "OptionValue Created Successfully!"
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
