using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Infrastructure.Data;
using SpilSalesOrder.Application.Interfaces;
using SpilSalesOrder.Application.Services;
using SpilSalesOrder.Infrastructure.Repositories;
using SpilSalesOrder.Application.MappingProfiles;
using SpilSalesOrder.Application.DTOs;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add application services.
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

// Client Endpoints
app.MapGet("/api/Client", async (IClientService clientService) =>
{
    var clients = await clientService.GetAllClients();
    return Results.Ok(clients);
});

app.MapGet("/api/Client/{id}", async (long id, IClientService clientService) =>
{
    var client = await clientService.GetClientByIdAsync(id);
    return client != null ? Results.Ok(client) : Results.NotFound();
});

app.MapPost("/api/Client", async (ClientDto clientDto, IClientService clientService) =>
{
    var newClient = await clientService.CreateClientAsync(clientDto);
    return Results.Created($"/api/Client/{newClient.Id}", newClient);
});

app.MapPut("/api/Client/{id}", async (long id, ClientDto clientDto, IClientService clientService) =>
{
    var updatedClient = await clientService.UpdateClientAsync(id, clientDto);
    return updatedClient != null ? Results.Ok(updatedClient) : Results.NotFound();
});

app.MapDelete("/api/Client/{id}", async (long id, IClientService clientService) =>
{
    var result = await clientService.DeleteClientAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});

// Item Endpoints
app.MapGet("/api/Item", async (IItemService itemService) =>
{
    var items = await itemService.GetAllItemsAsync();
    return Results.Ok(items);
});

app.MapGet("/api/Item/{id}", async (long id, IItemService itemService) =>
{
    var item = await itemService.GetItemByIdAsync(id);
    return item != null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/api/Item", async (ItemDto itemDto, IItemService itemService) =>
{
    var newItem = await itemService.CreateItemAsync(itemDto);
    return Results.Created($"/api/Item/{newItem.Id}", newItem);
});

app.MapPut("/api/Item/{id}", async (long id, ItemDto itemDto, IItemService itemService) =>
{
    var updatedItem = await itemService.UpdateItemAsync(id, itemDto);
    return updatedItem != null ? Results.Ok(updatedItem) : Results.NotFound();
});

app.MapDelete("/api/Item/{id}", async (long id, IItemService itemService) =>
{
    var result = await itemService.DeleteItemAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});

// Order Endpoints
app.MapGet("/api/Order/next-invoice-number", async (IOrderService orderService) =>
{
    var nextInvoiceNumber = await orderService.GetNextInvoiceNumberAsync();
    return Results.Ok(nextInvoiceNumber);
});

app.MapGet("/api/Order", async (IOrderService orderService) =>
{
    var orders = await orderService.GetAllOrdersAsync();
    return Results.Ok(orders);
});

app.MapGet("/api/Order/{id}", async (long id, IOrderService orderService) =>
{
    var order = await orderService.GetOrderByIdAsync(id);
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.MapPost("/api/Order", async (OrderDto orderDto, IOrderService orderService) =>
{
    var newOrder = await orderService.CreateOrderAsync(orderDto);
    return Results.Created($"/api/Order/{newOrder.Id}", newOrder);
});

app.MapPut("/api/Order/{id}", async (long id, OrderDto orderDto, IOrderService orderService) =>
{
    var updatedOrder = await orderService.UpdateOrderAsync(id, orderDto);
    return updatedOrder != null ? Results.Ok(updatedOrder) : Results.NotFound();
});

app.MapDelete("/api/Order/{id}", async (long id, IOrderService orderService) =>
{
    var result = await orderService.DeleteOrderAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});

app.Run();
