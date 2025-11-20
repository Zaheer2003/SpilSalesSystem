using AutoMapper;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;
using SpilSalesOrder.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            return _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto> CreateItemAsync(ItemDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            var newItem = await _itemRepository.AddItemAsync(item);
            return _mapper.Map<ItemDto>(newItem);
        }

        public async Task<ItemDto> UpdateItemAsync(int id, ItemDto itemDto)
        {
            var existingItem = await _itemRepository.GetItemByIdAsync(id);
            if (existingItem == null) return null;

            _mapper.Map(itemDto, existingItem);
            var updatedItem = await _itemRepository.UpdateItemAsync(existingItem);
            return _mapper.Map<ItemDto>(updatedItem);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var itemToDelete = await _itemRepository.GetItemByIdAsync(id);
            if (itemToDelete == null) return false;

            await _itemRepository.DeleteItemAsync(itemToDelete);
            return true;
        }
    }
}
