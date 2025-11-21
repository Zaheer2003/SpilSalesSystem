using SpilSalesOrder.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync();
        Task<ItemDto> GetItemByIdAsync(long id);
        Task<ItemDto> CreateItemAsync(ItemDto itemDto);
        Task<ItemDto> UpdateItemAsync(long id, ItemDto itemDto);
        Task<bool> DeleteItemAsync(long id);
    }
}