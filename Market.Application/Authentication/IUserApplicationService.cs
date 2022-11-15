using Market.Domain.Models;
using Market.Domain.Models.Authentication;

namespace Market.Application.Authentication
{
    public interface IUserApplicationService
    {
        Task<ResponseModel> CreateUser(RegisterModel model);
        Task<ResponseModel> Login(LoginModel model);
    }
}