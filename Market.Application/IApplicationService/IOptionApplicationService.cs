
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IOptionApplicationService
    {
        Task<ResponseModel> AddOption(OptionDto newOption);
        Task<ResponseModel> RemoveOptionById(Guid optionId);
        Task<ResponseModel> GetAllOptions();
        Task<ResponseModel> GetOptions(Func<Option, bool> expression);
        Task<ResponseModel> UpdateOption(OptionDto option);
        Task<ResponseModel> GetOptionById(Guid optionId);
    }
}
