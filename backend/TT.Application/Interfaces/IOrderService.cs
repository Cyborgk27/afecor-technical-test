using TT.Application.Commons.Bases;
using TT.Domain.Entities;

namespace TT.Application.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<IEnumerable<Order>>> GetAllAsync();
        Task<BaseResponse<Order>> GetByIdAsync(int id);
        Task<BaseResponse<Order>> CreateAsync(Order order);
        Task<BaseResponse<Order>> UpdateAsync(Order order);
        Task<BaseResponse<bool>> DeleteAsync(int id);
    }
}
