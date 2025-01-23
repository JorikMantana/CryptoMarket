using Mapster;
using Orders.BLL.DTOs;
using Orders.BLL.Services.Interfaces;
using Orders.DAL.Models;
using Orders.DAL.Repositories.Interfaces;

namespace Orders.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task AddOrder(OrderDto orderDto)
    {
        var order = orderDto.Adapt<Order>();
        
        await _orderRepository.AddOrder(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrders()
    {
        var orders = await _orderRepository.GetOrders();
        
        return orders.Adapt<IEnumerable<OrderDto>>();
    }

    public async Task<OrderDto> GetOrderById(int orderId)
    {
        var order = await _orderRepository.GetOrderById(orderId);
        
        return order.Adapt<OrderDto>();
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderRepository.GetOrdersByCustomerId(customerId);
        
        return orders.Adapt<IEnumerable<OrderDto>>();
    }
}