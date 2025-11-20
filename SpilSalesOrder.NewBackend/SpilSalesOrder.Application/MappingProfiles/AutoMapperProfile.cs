using AutoMapper;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Domain.Entities;

namespace SpilSalesOrder.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, ClientDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<SalesOrder, OrderDto>().ReverseMap();
            CreateMap<OrderItem, SalesOrderItemDto>().ReverseMap();
        }
    }
}
