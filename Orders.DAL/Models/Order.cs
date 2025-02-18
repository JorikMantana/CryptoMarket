namespace Orders.DAL.Models;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; } //Id продукта
    public int CustomerId { get; set; } //Id пользователя
}