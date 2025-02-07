using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.BLL.DTOs;
using Orders.BLL.Services.Interfaces;
using Orders.DAL.Models;

namespace Orders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddOrder(OrderDto orderDto)
    {
        await _orderService.AddOrder(orderDto);
        return Ok();
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        var orders = await _orderService.GetOrders();
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);
        return Ok(order);
    }

    [HttpGet("{customerId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerId(customerId);
        return Ok(orders);
    }
}