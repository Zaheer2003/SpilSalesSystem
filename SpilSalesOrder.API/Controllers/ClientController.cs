using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(long id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest();
            }
            var createdClient = await _clientService.CreateClientAsync(clientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(long id, [FromBody] ClientDto clientDto)
        {
            if (clientDto == null || id != clientDto.Id)
            {
                return BadRequest();
            }

            var updatedClient = await _clientService.UpdateClientAsync(id, clientDto);
            if (updatedClient == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
