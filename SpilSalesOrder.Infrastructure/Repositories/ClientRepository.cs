using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Domain.Entities;
using SpilSalesOrder.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllClientsAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetClientByIdAsync(long id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> AddClientAsync(Customer client)
        {
            await _context.Customers.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Customer> UpdateClientAsync(Customer client)
        {
            _context.Customers.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Customer client)
        {
            _context.Customers.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
