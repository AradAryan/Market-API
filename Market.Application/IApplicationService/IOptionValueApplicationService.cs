
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IOptionValueApplicationService
    {
        Task<ResponseModel> AddOptionValue(OptionValueDto newOptionValue);
        Task<ResponseModel> RemoveOptionValueById(Guid optionValueId);
        Task<ResponseModel> GetAllOptionValues();
        Task<ResponseModel> GetOptionValues(Func<OptionValue, bool> expression);
        Task<ResponseModel> UpdateOptionValue(OptionValueDto optionValue);
        Task<ResponseModel> GetOptionValueById(Guid optionValueId);
    }
}
