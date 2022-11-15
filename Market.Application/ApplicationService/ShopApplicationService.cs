using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ShopApplicationService : BaseApplicationService, IShopApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ShopApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddShop(ShopDto newShop)
        {
            try
            {
                var shop = Mapper.Map<ShopDto, Shop>(newShop);
                shop.CreateDate = DateTime.Now;

                await DbContext.Shops.AddAsync(shop);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Shop Created Successfully!"
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
        public async Task<ResponseModel> RemoveShopById(Guid shopId)
        {
            try
            {
                var shop = await DbContext.Shops.FirstOrDefaultAsync(c => c.Id == shopId);
                if (shop is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Shop Not Found!"
                    };

                DbContext.Shops.Remove(shop);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Shop Removed Successfully!"
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
        public async Task<ResponseModel> GetAllShops()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Shop, ShopDto>(await DbContext.Shops.ToListAsync())
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
        public async Task<ResponseModel> GetShops(Func<Shop, bool> expression)
        {
            try
            {
                IEnumerable<ShopDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Shop, ShopDto>(DbContext.Shops.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetShopById(Guid shopId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Shop, ShopDto>(await DbContext.Shops.FirstOrDefaultAsync(c => c.Id == shopId))
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
        public async Task<ResponseModel> UpdateShop(ShopDto shop)
        {
            try
            {
                var result = await DbContext.Shops.FirstOrDefaultAsync(c => c.Id == shop.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Shop Not Found!"
                    };
                result = Mapper.Map<ShopDto, Shop>(shop);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Shop Created Successfully!"
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
