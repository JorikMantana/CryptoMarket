using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Models;
using Orders.DAL.Repositories.Interfaces;

namespace Orders.DAL.Repositories;

public class OrdersRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrdersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderById(int orderId)
    {
        return await _context.Orders.FirstOrDefaultAsync(w => w.Id == orderId);
    }

    public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
    {
        return await _context.Orders.Where(w => w.CustomerId == customerId).ToListAsync();
    }
}