using TT.Application.Commons.Bases;
using TT.Domain.Entities;

namespace TT.Application.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<IEnumerable<Product>>> GetAvailableAsync();
    }
}
