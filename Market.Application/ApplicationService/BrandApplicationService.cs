using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class BrandApplicationService : BaseApplicationService, IBrandApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public BrandApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddBrand(BrandDto newBrand)
        {
            try
            {
                var brand = Mapper.Map<BrandDto, Brand>(newBrand);
                brand.CreateDate = DateTime.Now;

                await DbContext.Brands.AddAsync(brand);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Brand Created Successfully!"
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
        public async Task<ResponseModel> RemoveBrandById(Guid brandId)
        {
            try
            {
                var brand = await DbContext.Brands.FirstOrDefaultAsync(c => c.Id == brandId);
                if (brand is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Brand Not Found!"
                    };

                DbContext.Brands.Remove(brand);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Brand Removed Successfully!"
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
        public async Task<ResponseModel> GetAllBrands()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Brand, BrandDto>(await DbContext.Brands.ToListAsync())
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
        public async Task<ResponseModel> GetBrands(Func<Brand, bool> expression)
        {
            try
            {
                IEnumerable<BrandDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Brand, BrandDto>(DbContext.Brands.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetBrandById(Guid brandId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Brand, BrandDto>(await DbContext.Brands.FirstOrDefaultAsync(c => c.Id == brandId))
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
        public async Task<ResponseModel> UpdateBrand(BrandDto brand)
        {
            try
            {
                var result = await DbContext.Brands.FirstOrDefaultAsync(c => c.Id == brand.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Brand Not Found!"
                    };
                result = Mapper.Map<BrandDto, Brand>(brand);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Brand Created Successfully!"
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
