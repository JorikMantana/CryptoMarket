using System.ComponentModel.DataAnnotations;

namespace Comments.BLL.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
}