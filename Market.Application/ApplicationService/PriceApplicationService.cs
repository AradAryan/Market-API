using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class PriceApplicationService : BaseApplicationService, IPriceApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public PriceApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddPrice(PriceDto newPrice)
        {
            try
            {
                var price = Mapper.Map<PriceDto, Price>(newPrice);
                price.CreateDate = DateTime.Now;

                await DbContext.Prices.AddAsync(price);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Price Created Successfully!"
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
        public async Task<ResponseModel> RemovePriceById(Guid priceId)
        {
            try
            {
                var price = await DbContext.Prices.FirstOrDefaultAsync(c => c.Id == priceId);
                if (price is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Price Not Found!"
                    };

                DbContext.Prices.Remove(price);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Price Removed Successfully!"
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
        public async Task<ResponseModel> GetAllPrices()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Price, PriceDto>(await DbContext.Prices.ToListAsync())
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
        public async Task<ResponseModel> GetPrices(Func<Price, bool> expression)
        {
            try
            {
                IEnumerable<PriceDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Price, PriceDto>(DbContext.Prices.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetPriceById(Guid priceId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Price, PriceDto>(await DbContext.Prices.FirstOrDefaultAsync(c => c.Id == priceId))
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
        public async Task<ResponseModel> UpdatePrice(PriceDto price)
        {
            try
            {
                var result = await DbContext.Prices.FirstOrDefaultAsync(c => c.Id == price.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Price Not Found!"
                    };
                result = Mapper.Map<PriceDto, Price>(price);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Price Created Successfully!"
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
