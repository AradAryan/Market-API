using Market.Domain.Models.Authentication;
using Market.Domain.Models;

namespace Market.Application.Authentication
{
    public interface IRoleApplicationService
    {
        Task<ResponseModel> CreateRole(string roleName);
        Task<ResponseModel> AssignRole(string username, string roleName);

    }
}