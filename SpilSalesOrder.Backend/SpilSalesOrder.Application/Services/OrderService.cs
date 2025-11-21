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

            // Generate InvoiceNo if not provided
            if (string.IsNullOrEmpty(order.InvoiceNo))
            {
                string? lastInvoiceNo = await _orderRepository.GetLastInvoiceNumberAsync();
                int nextInvoiceNumber = 1;

                if (!string.IsNullOrEmpty(lastInvoiceNo) && lastInvoiceNo.StartsWith("INV-"))
                {
                    string numericPart = lastInvoiceNo.Substring(4); // "INV-".Length is 4
                    if (int.TryParse(numericPart, out int lastNumber))
                    {
                        nextInvoiceNumber = lastNumber + 1;
                    }
                }
                order.InvoiceNo = $"INV-{nextInvoiceNumber:D4}"; // D4 formats to 4 digits with leading zeros
            }

            if (string.IsNullOrEmpty(order.ReferenceNo))
            {
                order.ReferenceNo = "";
            }

            order.CreatedAt = DateTime.UtcNow;
            order.UpdatedAt = DateTime.UtcNow;

            var newOrder = await _orderRepository.AddOrderAsync(order);
            return _mapper.Map<OrderDto>(newOrder);
        }

        public async Task<OrderDto> UpdateOrderAsync(long id, OrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null) return null;

            _mapper.Map(orderDto, existingOrder);

            existingOrder.UpdatedAt = DateTime.UtcNow;

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

        public async Task<string> GetNextInvoiceNumberAsync()
        {
            string? lastInvoiceNo = await _orderRepository.GetLastInvoiceNumberAsync();
            int nextInvoiceNumber = 1;

            if (!string.IsNullOrEmpty(lastInvoiceNo) && lastInvoiceNo.StartsWith("INV-"))
            {
                string numericPart = lastInvoiceNo.Substring(4); // "INV-".Length is 4
                if (int.TryParse(numericPart, out int lastNumber))
                {
                    nextInvoiceNumber = lastNumber + 1;
                }
            }
            return $"INV-{nextInvoiceNumber:D4}"; // D4 formats to 4 digits with leading zeros
        }
    }
}