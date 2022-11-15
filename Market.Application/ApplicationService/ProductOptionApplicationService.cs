using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ProductOptionApplicationService : BaseApplicationService, IProductOptionApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ProductOptionApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddProductOption(ProductOptionDto newProductOption)
        {
            try
            {
                var productOption = Mapper.Map<ProductOptionDto, ProductOption>(newProductOption);
                productOption.CreateDate = DateTime.Now;

                await DbContext.ProductOptions.AddAsync(productOption);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductOption Created Successfully!"
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
        public async Task<ResponseModel> RemoveProductOptionById(Guid productOptionId)
        {
            try
            {
                var productOption = await DbContext.ProductOptions.FirstOrDefaultAsync(c => c.Id == productOptionId);
                if (productOption is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductOption Not Found!"
                    };

                DbContext.ProductOptions.Remove(productOption);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "ProductOption Removed Successfully!"
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
        public async Task<ResponseModel> GetAllProductOptions()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<ProductOption, ProductOptionDto>(await DbContext.ProductOptions.ToListAsync())
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
        public async Task<ResponseModel> GetProductOptions(Func<ProductOption, bool> expression)
        {
            try
            {
                IEnumerable<ProductOptionDto> data = default;
                await Task.Run(() => data = Mapper.MapList<ProductOption, ProductOptionDto>(DbContext.ProductOptions.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetProductOptionById(Guid productOptionId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<ProductOption, ProductOptionDto>(await DbContext.ProductOptions.FirstOrDefaultAsync(c => c.Id == productOptionId))
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
        public async Task<ResponseModel> UpdateProductOption(ProductOptionDto productOption)
        {
            try
            {
                var result = await DbContext.ProductOptions.FirstOrDefaultAsync(c => c.Id == productOption.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductOption Not Found!"
                    };
                result = Mapper.Map<ProductOptionDto, ProductOption>(productOption);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductOption Created Successfully!"
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
