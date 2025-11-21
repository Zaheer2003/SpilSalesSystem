using AutoMapper;
using SpilSalesOrder.Application.DTOs;
using SpilSalesOrder.Domain.Entities;

namespace SpilSalesOrder.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, ClientDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName))
                .ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<SalesOrder, OrderDto>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItemsList));
            CreateMap<OrderDto, SalesOrder>()
                .ForMember(dest => dest.OrderItemsList, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<SalesOrderItem, SalesOrderItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemCode, opt => opt.MapFrom(src => src.Item.ItemCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Item.Description))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Item.Note))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.TaxRate))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TotalExel, opt => opt.MapFrom(src => src.ExclAmount))
                .ForMember(dest => dest.TotalTax, opt => opt.MapFrom(src => src.TaxAmount))
                .ForMember(dest => dest.TotalIncl, opt => opt.MapFrom(src => src.InclAmount));
            
            CreateMap<SalesOrderItemDto, SalesOrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.TaxRate))
                .ForMember(dest => dest.ExclAmount, opt => opt.MapFrom(src => src.TotalExel))
                .ForMember(dest => dest.TaxAmount, opt => opt.MapFrom(src => src.TotalTax))
                .ForMember(dest => dest.InclAmount, opt => opt.MapFrom(src => src.TotalIncl));
        }
    }
}
