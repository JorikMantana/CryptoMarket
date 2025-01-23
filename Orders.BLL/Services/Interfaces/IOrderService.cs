using Orders.BLL.DTOs;

namespace Orders.BLL.Services.Interfaces;

public interface IOrderService
{
    public Task AddOrder(OrderDto orderDto);
    public Task<IEnumerable<OrderDto>> GetOrders();
    public Task<OrderDto> GetOrderById(int orderId);
    public Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int customerId);
}