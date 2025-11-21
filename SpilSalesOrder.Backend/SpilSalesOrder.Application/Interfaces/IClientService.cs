using SpilSalesOrder.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClients();

        Task<ClientDto> GetClientByIdAsync(long id);

        Task<ClientDto> CreateClientAsync(ClientDto clientDto);

        Task<ClientDto> UpdateClientAsync(long id, ClientDto clientDto);

        Task<bool> DeleteClientAsync(long id);
    }
}
