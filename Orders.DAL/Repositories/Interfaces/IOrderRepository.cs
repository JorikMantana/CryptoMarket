using Orders.DAL.Models;

namespace Orders.DAL.Repositories.Interfaces;

public interface IOrderRepository
{
    public Task AddOrder(Order order);
    public Task<List<Order>> GetOrders();
    public Task<Order> GetOrderById(int orderId);
    public Task<List<Order>> GetOrdersByCustomerId(int customerId);
}