using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ShopProductOptionValueApplicationService : BaseApplicationService, IShopProductOptionValueApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ShopProductOptionValueApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddShopProductOptionValue(ShopProductOptionValueDto newShopProductOptionValue)
        {
            try
            {
                var shopProductOptionValue = Mapper.Map<ShopProductOptionValueDto, ShopProductOptionValue>(newShopProductOptionValue);
                shopProductOptionValue.CreateDate = DateTime.Now;

                await DbContext.ShopProductOptionValues.AddAsync(shopProductOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ShopProductOptionValue Created Successfully!"
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
        public async Task<ResponseModel> RemoveShopProductOptionValueById(Guid shopProductOptionValueId)
        {
            try
            {
                var shopProductOptionValue = await DbContext.ShopProductOptionValues.FirstOrDefaultAsync(c => c.Id == shopProductOptionValueId);
                if (shopProductOptionValue is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ShopProductOptionValue Not Found!"
                    };

                DbContext.ShopProductOptionValues.Remove(shopProductOptionValue);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "ShopProductOptionValue Removed Successfully!"
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
        public async Task<ResponseModel> GetAllShopProductOptionValues()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<ShopProductOptionValue, ShopProductOptionValueDto>(await DbContext.ShopProductOptionValues.ToListAsync())
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
        public async Task<ResponseModel> GetShopProductOptionValues(Func<ShopProductOptionValue, bool> expression)
        {
            try
            {
                IEnumerable<ShopProductOptionValueDto> data = default;
                await Task.Run(() => data = Mapper.MapList<ShopProductOptionValue, ShopProductOptionValueDto>(DbContext.ShopProductOptionValues.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetShopProductOptionValueById(Guid shopProductOptionValueId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<ShopProductOptionValue, ShopProductOptionValueDto>(await DbContext.ShopProductOptionValues.FirstOrDefaultAsync(c => c.Id == shopProductOptionValueId))
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
        public async Task<ResponseModel> UpdateShopProductOptionValue(ShopProductOptionValueDto shopProductOptionValue)
        {
            try
            {
                var result = await DbContext.ShopProductOptionValues.FirstOrDefaultAsync(c => c.Id == shopProductOptionValue.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ShopProductOptionValue Not Found!"
                    };
                result = Mapper.Map<ShopProductOptionValueDto, ShopProductOptionValue>(shopProductOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ShopProductOptionValue Created Successfully!"
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
