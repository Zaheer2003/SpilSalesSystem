using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Domain.Entities;
using SpilSalesOrder.Infrastructure.Data;
using SpilSalesOrder.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpilSalesOrder.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllOrdersAsync()
        {
            return await _context.SalesOrder.Include(o => o.OrderItemsList).ToListAsync();
        }

        public async Task<SalesOrder> GetOrderByIdAsync(long id)
        {
            return await _context.SalesOrder
                                 .Include(o => o.OrderItemsList)
                                 .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<SalesOrder> AddOrderAsync(SalesOrder order)
        {
            await _context.SalesOrder.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<SalesOrder> UpdateOrderAsync(SalesOrder order)
        {
            _context.SalesOrder.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(SalesOrder order)
        {
            _context.SalesOrder.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
