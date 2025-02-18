using System.ComponentModel.DataAnnotations;

namespace Comments.DAL.Models;

public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; } //Отзыв
    public int UserId { get; set; } //Id пользователя 
    public int ProductId { get; set; } //Id продукта
    [Range(1, 5)]
    public int Rating { get; set; } //Рейтинг в оценке 
}