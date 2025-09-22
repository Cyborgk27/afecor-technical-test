using TT.Application.Commons.Bases;
using TT.Application.Dtos.Order;
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
            var order = await _orderRepo.GetByIdAsync(id, o => o.Details);

            if (order == null)
                return ResponseFactory.NotFound<Order>("Pedido no encontrado");

            return ResponseFactory.Success(order, "Pedido encontrado");
        }

        public async Task<BaseResponse<Order>> CreateAsync(OrderCreateDto dto)
        {
            var order = new Order(dto.ClientId, dto.OrderDate);

            foreach (var d in dto.Details)
            {
                order.AddDetail(d.ProductId, d.Price, d.Quantity);
            }

            var created = await _orderRepo.AddAsync(order);
            return ResponseFactory.Created(created, "Pedido creado exitosamente");
        }

        public async Task<BaseResponse<Order>> UpdateAsync(OrderUpdateDto dto)
        {
            var existingOrder = await _orderRepo.GetByIdAsync(dto.Id);
            if (existingOrder == null)
                return ResponseFactory.NotFound<Order>("Pedido no existe");


            existingOrder.UpdateClient(dto.ClientId);
            existingOrder.UpdateOrderDate(dto.OrderDate);


            existingOrder.ClearDetails();
            foreach (var d in dto.Details)
            {
                existingOrder.AddDetail(d.ProductId, d.Price, d.Quantity);
            }

            var updated = await _orderRepo.UpdateAsync(existingOrder);
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
