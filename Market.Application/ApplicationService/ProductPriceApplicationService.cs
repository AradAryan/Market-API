using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ProductPriceApplicationService : BaseApplicationService, IProductPriceApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ProductPriceApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddProductPrice(ProductPriceDto newProductPrice)
        {
            try
            {
                var productPrice = Mapper.Map<ProductPriceDto, ProductPrice>(newProductPrice);
                productPrice.CreateDate = DateTime.Now;

                await DbContext.ProductPrices.AddAsync(productPrice);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductPrice Created Successfully!"
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
        public async Task<ResponseModel> RemoveProductPriceById(Guid productPriceId)
        {
            try
            {
                var productPrice = await DbContext.ProductPrices.FirstOrDefaultAsync(c => c.Id == productPriceId);
                if (productPrice is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductPrice Not Found!"
                    };

                DbContext.ProductPrices.Remove(productPrice);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "ProductPrice Removed Successfully!"
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
        public async Task<ResponseModel> GetAllProductPrices()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<ProductPrice, ProductPriceDto>(await DbContext.ProductPrices.ToListAsync())
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
        public async Task<ResponseModel> GetProductPrices(Func<ProductPrice, bool> expression)
        {
            try
            {
                IEnumerable<ProductPriceDto> data = default;
                await Task.Run(() => data = Mapper.MapList<ProductPrice, ProductPriceDto>(DbContext.ProductPrices.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetProductPriceById(Guid productPriceId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<ProductPrice, ProductPriceDto>(await DbContext.ProductPrices.FirstOrDefaultAsync(c => c.Id == productPriceId))
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
        public async Task<ResponseModel> UpdateProductPrice(ProductPriceDto productPrice)
        {
            try
            {
                var result = await DbContext.ProductPrices.FirstOrDefaultAsync(c => c.Id == productPrice.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductPrice Not Found!"
                    };
                result = Mapper.Map<ProductPriceDto, ProductPrice>(productPrice);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductPrice Created Successfully!"
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
