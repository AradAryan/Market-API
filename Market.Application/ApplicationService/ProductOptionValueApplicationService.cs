using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ProductOptionValueApplicationService : BaseApplicationService, IProductOptionValueApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ProductOptionValueApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddProductOptionValue(ProductOptionValueDto newProductOptionValue)
        {
            try
            {
                var productOptionValue = Mapper.Map<ProductOptionValueDto, ProductOptionValue>(newProductOptionValue);
                productOptionValue.CreateDate = DateTime.Now;

                await DbContext.ProductOptionValues.AddAsync(productOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductOptionValue Created Successfully!"
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
        public async Task<ResponseModel> RemoveProductOptionValueById(Guid productOptionValueId)
        {
            try
            {
                var productOptionValue = await DbContext.ProductOptionValues.FirstOrDefaultAsync(c => c.Id == productOptionValueId);
                if (productOptionValue is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductOptionValue Not Found!"
                    };

                DbContext.ProductOptionValues.Remove(productOptionValue);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "ProductOptionValue Removed Successfully!"
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
        public async Task<ResponseModel> GetAllProductOptionValues()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<ProductOptionValue, ProductOptionValueDto>(await DbContext.ProductOptionValues.ToListAsync())
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
        public async Task<ResponseModel> GetProductOptionValues(Func<ProductOptionValue, bool> expression)
        {
            try
            {
                IEnumerable<ProductOptionValueDto> data = default;
                await Task.Run(() => data = Mapper.MapList<ProductOptionValue, ProductOptionValueDto>(DbContext.ProductOptionValues.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetProductOptionValueById(Guid productOptionValueId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<ProductOptionValue, ProductOptionValueDto>(await DbContext.ProductOptionValues.FirstOrDefaultAsync(c => c.Id == productOptionValueId))
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
        public async Task<ResponseModel> UpdateProductOptionValue(ProductOptionValueDto productOptionValue)
        {
            try
            {
                var result = await DbContext.ProductOptionValues.FirstOrDefaultAsync(c => c.Id == productOptionValue.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "ProductOptionValue Not Found!"
                    };
                result = Mapper.Map<ProductOptionValueDto, ProductOptionValue>(productOptionValue);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "ProductOptionValue Created Successfully!"
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
