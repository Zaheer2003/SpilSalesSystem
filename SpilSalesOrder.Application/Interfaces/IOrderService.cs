using SpilSalesOrder.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Enumerable<OrderDto>> GetAllOrdersAsyn();

        Task<OrderDto> GetOrderByIdAsync(long id);

        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);

        Task<OrderDto> UpdateOrderAsync(OrderDto orderDto);

        Task DeleteOrderAsync(long id);
    }
}
