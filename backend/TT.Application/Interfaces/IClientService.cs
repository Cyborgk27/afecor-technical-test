using TT.Application.Commons.Bases;
using TT.Domain.Entities;

namespace TT.Application.Interfaces
{
    public interface IClientService
    {
        Task<BaseResponse<IEnumerable<Client>>> GetAvailableAsync();
    }
}
