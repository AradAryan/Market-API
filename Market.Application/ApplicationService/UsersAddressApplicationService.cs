using Application;
using Market.Domain;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application
{
    public class UsersAddressApplicationService : BaseApplicationService, IUsersAddressApplicationService
    {
        private ApplicationContext DbContext { get; set; }

        public UsersAddressApplicationService(ApplicationContext dbContext) : base()
        {
            DbContext = dbContext;
        }

        public async Task<ResponseModel> AddUsersAddress(UsersAddressDto newUsersAddress)
        {
            try
            {
                var usersAddress = Mapper.Map<UsersAddressDto, UsersAddress>(newUsersAddress);
                usersAddress.CreateDate = DateTime.Now;

                await DbContext.UsersAddresses.AddAsync(usersAddress);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "UsersAddress Created Successfully!"
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
        public async Task<ResponseModel> RemoveUsersAddressById(Guid usersAddressId)
        {
            try
            {
                var usersAddress = await DbContext.UsersAddresses.FirstOrDefaultAsync(c => c.Id == usersAddressId);
                if (usersAddress is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "UsersAddress Not Found!"
                    };

                DbContext.UsersAddresses.Remove(usersAddress);
                await DbContext.SaveChangesAsync();
                return new()
                {
                    Succeed = true,
                    Message = "UsersAddress Removed Successfully!"
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
        public async Task<ResponseModel> GetAllUsersAddresses()
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.MapList<UsersAddress, UsersAddressDto>(await DbContext.UsersAddresses.ToListAsync())
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
        public async Task<ResponseModel> GetUsersAddresses(Func<UsersAddress, bool> expression)
        {
            try
            {
                IEnumerable<UsersAddressDto> data = default;
                await Task.Run(() => data = Mapper.MapList<UsersAddress, UsersAddressDto>(DbContext.UsersAddresses.Where(expression).ToList()));
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
        public async Task<ResponseModel> GetUsersAddressById(Guid usersAddressId)
        {
            try
            {
                return new()
                {
                    Succeed = true,
                    Data = Mapper.Map<UsersAddress, UsersAddressDto>(await DbContext.UsersAddresses.FirstOrDefaultAsync(c => c.Id == usersAddressId))
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
        public async Task<ResponseModel> UpdateUsersAddress(UsersAddressDto usersAddress)
        {
            try
            {
                var result = await DbContext.UsersAddresses.FirstOrDefaultAsync(c => c.Id == usersAddress.Id);
                if (result is null)
                    return new()
                    {
                        Succeed = false,
                        Message = "UsersAddress Not Found!"
                    };
                result = Mapper.Map<UsersAddressDto, UsersAddress>(usersAddress);
                DbContext.SaveChanges();

                return new()
                {
                    Succeed = true,
                    Message = "UsersAddress Created Successfully!"
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
