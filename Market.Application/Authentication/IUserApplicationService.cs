using Market.Domain.Models.Authentication;
using Market.Domain.Models;

namespace Market.Application.Authentication
{
    public interface IUserApplicationService
    {
        Task<ResponseModel> CreateUser(RegisterModel model);
        Task<ResponseModel> Login(LoginModel model);
    }
}