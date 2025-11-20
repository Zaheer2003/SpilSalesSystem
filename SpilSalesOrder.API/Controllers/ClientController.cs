using Microsoft.AspNetCore.Mvc;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;   
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IclientService _clientService;

        public ClientController(IclientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("api/clients")]
        public async Task<ActionResult<List<ClientDto>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(long id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(ClientDto clientDto)
        {
            var createdClient = await _clientService.CreateClient(clientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(long id, ClientDto clientDto)
        {
            if (id != clientDto.Id)
            {
                return NotFound();
            }
            return Ok(UpdateClient);
        }


    }
}
