using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class FactorApplicationService : BaseApplicationService, IFactorApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public FactorApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddFactor(FactorDto newFactor)
        {
            try
            {
                var factor = Mapper.Map<FactorDto, Factor>(newFactor);
                factor.CreateDate = DateTime.Now;

                await DbContext.Factors.AddAsync(factor);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Factor Created Successfully!"
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
        public async Task<ResponseModel> RemoveFactorById(Guid factorId)
        {
            try
            {
                var factor = await DbContext.Factors.FirstOrDefaultAsync(c => c.Id == factorId);
                if (factor is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Factor Not Found!"
                    };

                DbContext.Factors.Remove(factor);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Factor Removed Successfully!"
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
        public async Task<ResponseModel> GetAllFactors()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Factor, FactorDto>(await DbContext.Factors.ToListAsync())
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
        public async Task<ResponseModel> GetFactors(Func<Factor, bool> expression)
        {
            try
            {
                IEnumerable<FactorDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Factor, FactorDto>(DbContext.Factors.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetFactorById(Guid factorId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Factor, FactorDto>(await DbContext.Factors.FirstOrDefaultAsync(c => c.Id == factorId))
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
        public async Task<ResponseModel> UpdateFactor(FactorDto factor)
        {
            try
            {
                var result = await DbContext.Factors.FirstOrDefaultAsync(c => c.Id == factor.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Factor Not Found!"
                    };
                result = Mapper.Map<FactorDto, Factor>(factor);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Factor Created Successfully!"
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
