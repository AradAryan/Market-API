
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IAddressApplicationService
    {
        Task<ResponseModel> AddAddress(AddressDto newAddress);
        Task<ResponseModel> RemoveAddressById(Guid addressId);
        Task<ResponseModel> GetAllAddresses();
        Task<ResponseModel> GetAddresses(Func<Address, bool> expression);
        Task<ResponseModel> UpdateAddress(AddressDto address);
        Task<ResponseModel> GetAddressById(Guid addressId);
    }
}
