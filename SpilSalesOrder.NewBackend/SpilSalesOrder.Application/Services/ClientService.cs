using AutoMapper;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;
using SpilSalesOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetClientByIdAsync(long id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> CreateClientAsync(ClientDto clientDto)
        {
            var client = _mapper.Map<Customer>(clientDto);
            var newClient = await _clientRepository.AddClientAsync(client);
            return _mapper.Map<ClientDto>(newClient);
        }

        public async Task<ClientDto> UpdateClientAsync(long id, ClientDto clientDto)
        {
            var existingClient = await _clientRepository.GetClientByIdAsync(id);
            if (existingClient == null) return null;

            _mapper.Map(clientDto, existingClient);
            var updatedClient = await _clientRepository.UpdateClientAsync(existingClient);
            return _mapper.Map<ClientDto>(updatedClient);
        }

        public async Task<bool> DeleteClientAsync(long id)
        {
            var clientToDelete = await _clientRepository.GetClientByIdAsync(id);
            if (clientToDelete == null) return false;

            await _clientRepository.DeleteClientAsync(clientToDelete);
            return true;
        }
    }
}
