using TT.Application.Commons.Bases;
using TT.Application.Interfaces;
using TT.Domain.Entities;
using TT.Infrastructure.Persistences.Interfaces;

namespace TT.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order, int> _orderRepo;

        public OrderService(IGenericRepository<Order, int> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<BaseResponse<IEnumerable<Order>>> GetAllAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            return ResponseFactory.Success(orders.AsEnumerable(), "Pedidos obtenidos");
        }

        public async Task<BaseResponse<Order>> GetByIdAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null)
                return ResponseFactory.NotFound<Order>("Pedido no encontrado");

            return ResponseFactory.Success(order, "Pedido encontrado");
        }

        public async Task<BaseResponse<Order>> CreateAsync(Order order)
        {
            var created = await _orderRepo.AddAsync(order);
            return ResponseFactory.Created(created, "Pedido creado exitosamente");
        }

        public async Task<BaseResponse<Order>> UpdateAsync(Order order)
        {
            if (!await _orderRepo.ExistsAsync(order.Id))
                return ResponseFactory.NotFound<Order>("Pedido no existe");

            var updated = await _orderRepo.UpdateAsync(order);
            return ResponseFactory.Success(updated, "Pedido actualizado");
        }

        public async Task<BaseResponse<bool>> DeleteAsync(int id)
        {
            var deleted = await _orderRepo.DeleteAsync(id);
            if (!deleted)
                return ResponseFactory.NotFound<bool>("Pedido no encontrado");

            return ResponseFactory.Success(true, "Pedido eliminado");
        }
    }
}
