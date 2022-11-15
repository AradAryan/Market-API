using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class ProductApplicationService : BaseApplicationService, IProductApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public ProductApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddProduct(ProductDto newProduct)
        {
            try
            {
                var product = Mapper.Map<ProductDto, Product>(newProduct);
                product.CreateDate = DateTime.Now;

                await DbContext.Products.AddAsync(product);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Product Created Successfully!"
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
        public async Task<ResponseModel> RemoveProductById(Guid productId)
        {
            try
            {
                var product = await DbContext.Products.FirstOrDefaultAsync(c => c.Id == productId);
                if (product is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Product Not Found!"
                    };

                DbContext.Products.Remove(product);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Product Removed Successfully!"
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
        public async Task<ResponseModel> GetAllProducts()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Product, ProductDto>(await DbContext.Products.ToListAsync())
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
        public async Task<ResponseModel> GetProducts(Func<Product, bool> expression)
        {
            try
            {
                IEnumerable<ProductDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Product, ProductDto>(DbContext.Products.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetProductById(Guid productId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Product, ProductDto>(await DbContext.Products.FirstOrDefaultAsync(c => c.Id == productId))
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
        public async Task<ResponseModel> UpdateProduct(ProductDto product)
        {
            try
            {
                var result = await DbContext.Products.FirstOrDefaultAsync(c => c.Id == product.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Product Not Found!"
                    };
                result = Mapper.Map<ProductDto, Product>(product);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Product Created Successfully!"
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
