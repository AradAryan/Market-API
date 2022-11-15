
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IUsersAddressApplicationService
    {
        Task<ResponseModel> AddUsersAddress(UsersAddressDto newUsersAddress);
        Task<ResponseModel> RemoveUsersAddressById(Guid usersAddressId);
        Task<ResponseModel> GetAllUsersAddresses();
        Task<ResponseModel> GetUsersAddresses(Func<UsersAddress, bool> expression);
        Task<ResponseModel> UpdateUsersAddress(UsersAddressDto usersAddress);
        Task<ResponseModel> GetUsersAddressById(Guid usersAddressId);
    }
}
