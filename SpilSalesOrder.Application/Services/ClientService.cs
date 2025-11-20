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

        public async Task<List<ClientDto>> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClients();
            return _mapper.Map<List<ClientDto>>(clients);
        }
    }
}
