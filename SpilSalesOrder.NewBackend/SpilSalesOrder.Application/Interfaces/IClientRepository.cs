using SpilSalesOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Customer>> GetAllClientsAsync();
        Task<Customer> GetClientByIdAsync(long id);
        Task<Customer> AddClientAsync(Customer client);
        Task<Customer> UpdateClientAsync(Customer client);
        Task DeleteClientAsync(Customer client);
    }
}
