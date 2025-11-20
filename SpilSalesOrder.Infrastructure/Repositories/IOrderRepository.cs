using SpilSalesOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetAllOrdersAsync();
        Task<SalesOrder> GetOrderByIdAsync(long id);
        Task<SalesOrder> AddOrderAsync(SalesOrder order);
        Task<SalesOrder> UpdateOrderAsync(SalesOrder order);
        Task DeleteOrderAsync(SalesOrder order);
    }
}
