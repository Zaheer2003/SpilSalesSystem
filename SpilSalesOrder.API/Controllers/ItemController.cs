using Microsoft.AspNetCore.Mvc;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem([FromBody] ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest();
            }
            var createdItem = await _itemService.CreateItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItem(int id, [FromBody] ItemDto itemDto)
        {
            if (itemDto == null || id != itemDto.Id)
            {
                return BadRequest();
            }

            var updatedItem = await _itemService.UpdateItemAsync(id, itemDto);
            if (updatedItem == null)
            {
                return NotFound();
            }
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemService.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
