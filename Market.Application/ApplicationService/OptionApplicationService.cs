using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class OptionApplicationService : BaseApplicationService, IOptionApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public OptionApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddOption(OptionDto newOption)
        {
            try
            {
                var option = Mapper.Map<OptionDto, Option>(newOption);
                option.CreateDate = DateTime.Now;

                await DbContext.Options.AddAsync(option);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Option Created Successfully!"
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
        public async Task<ResponseModel> RemoveOptionById(Guid optionId)
        {
            try
            {
                var option = await DbContext.Options.FirstOrDefaultAsync(c => c.Id == optionId);
                if (option is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Option Not Found!"
                    };

                DbContext.Options.Remove(option);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Option Removed Successfully!"
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
        public async Task<ResponseModel> GetAllOptions()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Option, OptionDto>(await DbContext.Options.ToListAsync())
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
        public async Task<ResponseModel> GetOptions(Func<Option, bool> expression)
        {
            try
            {
                IEnumerable<OptionDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Option, OptionDto>(DbContext.Options.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetOptionById(Guid optionId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Option, OptionDto>(await DbContext.Options.FirstOrDefaultAsync(c => c.Id == optionId))
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
        public async Task<ResponseModel> UpdateOption(OptionDto option)
        {
            try
            {
                var result = await DbContext.Options.FirstOrDefaultAsync(c => c.Id == option.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Option Not Found!"
                    };
                result = Mapper.Map<OptionDto, Option>(option);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Option Created Successfully!"
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
