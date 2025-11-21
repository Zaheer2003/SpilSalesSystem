using SpilSalesOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetAllOrdersAsync();
        Task<SalesOrder> GetOrderByIdAsync(long id);
        Task<SalesOrder> AddOrderAsync(SalesOrder order);
        Task<SalesOrder> UpdateOrderAsync(SalesOrder order);
        Task DeleteOrderAsync(SalesOrder order);
        Task<string?> GetLastInvoiceNumberAsync(); // Add this line
    }
}
