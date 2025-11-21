using SpilSalesOrder.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

        Task<OrderDto> GetOrderByIdAsync(long id);

        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);

        Task<OrderDto> UpdateOrderAsync(long id, OrderDto orderDto);

        Task<bool> DeleteOrderAsync(long id);

        Task<string> GetNextInvoiceNumberAsync(); // Add this line
    }
}
