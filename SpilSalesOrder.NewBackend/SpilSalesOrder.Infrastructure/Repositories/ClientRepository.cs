using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Domain.Entities;
using SpilSalesOrder.Infrastructure.Data;
using SpilSalesOrder.Application.Interfaces;
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
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetClientByIdAsync(long id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<Customer> AddClientAsync(Customer client)
        {
            await _context.Customer.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Customer> UpdateClientAsync(Customer client)
        {
            _context.Customer.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Customer client)
        {
            _context.Customer.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}