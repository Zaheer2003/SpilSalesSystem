using SpilSalesOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<Item> GetItemByIdAsync(long id);

        Task<Item> AddItemAsync(Item item);

        Task<Item> UpdateItemAsync(Item item);

        Task DeleteItemAsync(Item item);

    }
}
