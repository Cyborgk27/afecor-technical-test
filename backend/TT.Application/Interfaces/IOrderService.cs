using TT.Application.Commons.Bases;
using TT.Application.Dtos.Order;
using TT.Domain.Entities;

namespace TT.Application.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<IEnumerable<Order>>> GetAllAsync();
        Task<BaseResponse<Order>> GetByIdAsync(int id);
        Task<BaseResponse<Order>> CreateAsync(OrderCreateDto order);
        Task<BaseResponse<Order>> UpdateAsync(OrderUpdateDto order);
        Task<BaseResponse<bool>> DeleteAsync(int id);
    }
}
