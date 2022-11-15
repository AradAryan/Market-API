using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class AddressApplicationService : BaseApplicationService, IAddressApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public AddressApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddAddress(AddressDto newAddress)
        {
            try
            {
                var address = Mapper.Map<AddressDto, Address>(newAddress);
                address.CreateDate = DateTime.Now;

                await DbContext.Addresses.AddAsync(address);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Address Created Successfully!"
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
        public async Task<ResponseModel> RemoveAddressById(Guid addressId)
        {
            try
            {
                var address = await DbContext.Addresses.FirstOrDefaultAsync(c => c.Id == addressId);
                if (address is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Address Not Found!"
                    };

                DbContext.Addresses.Remove(address);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "Address Removed Successfully!"
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
        public async Task<ResponseModel> GetAllAddresses()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<Address, AddressDto>(await DbContext.Addresses.ToListAsync())
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
        public async Task<ResponseModel> GetAddresses(Func<Address, bool> expression)
        {
            try
            {
                IEnumerable<AddressDto> data = default;
                await Task.Run(() => data = Mapper.MapList<Address, AddressDto>(DbContext.Addresses.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetAddressById(Guid addressId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<Address, AddressDto>(await DbContext.Addresses.FirstOrDefaultAsync(c => c.Id == addressId))
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
        public async Task<ResponseModel> UpdateAddress(AddressDto address)
        {
            try
            {
                var result = await DbContext.Addresses.FirstOrDefaultAsync(c => c.Id == address.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "Address Not Found!"
                    };
                result = Mapper.Map<AddressDto, Address>(address);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "Address Created Successfully!"
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
