using SpilSalesOrder.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync();
        Task<ItemDto> GetItemByIdAsync(int id);
        Task<ItemDto> CreateItemAsync(ItemDto itemDto);
        Task<ItemDto> UpdateItemAsync(int id, ItemDto itemDto);
        Task<bool> DeleteItemAsync(int id);
    }
}