using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Domain.Entities;
using SpilSalesOrder.Infrastructure.Data;
using SpilSalesOrder.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(long id)
        {
            return await _context.Item.FindAsync(id);
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            await _context.Item.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            _context.Item.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(Item item)
        {
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
