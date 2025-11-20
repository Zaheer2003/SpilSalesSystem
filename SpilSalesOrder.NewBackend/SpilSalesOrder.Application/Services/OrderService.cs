using AutoMapper;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Application.Interfaces;
using SpilSalesOrder.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpilSalesOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(long id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<SalesOrder>(orderDto);
            var newOrder = await _orderRepository.AddOrderAsync(order);
            return _mapper.Map<OrderDto>(newOrder);
        }

        public async Task<OrderDto> UpdateOrderAsync(long id, OrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null) return null;

            _mapper.Map(orderDto, existingOrder);
            var updatedOrder = await _orderRepository.UpdateOrderAsync(existingOrder);
            return _mapper.Map<OrderDto>(updatedOrder);
        }

        public async Task<bool> DeleteOrderAsync(long id)
        {
            var orderToDelete = await _orderRepository.GetOrderByIdAsync(id);
            if (orderToDelete == null) return false;

            await _orderRepository.DeleteOrderAsync(orderToDelete);
            return true;
        }
    }
}