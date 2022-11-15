
using Market.Domain;
using Market.Domain.Models;

namespace Market.Application
{
    public interface IFactorApplicationService
    {
        Task<ResponseModel> AddFactor(FactorDto newFactor);
        Task<ResponseModel> RemoveFactorById(Guid factorId);
        Task<ResponseModel> GetAllFactors();
        Task<ResponseModel> GetFactors(Func<Factor, bool> expression);
        Task<ResponseModel> UpdateFactor(FactorDto factor);
        Task<ResponseModel> GetFactorById(Guid factorId);
    }
}
