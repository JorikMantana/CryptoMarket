using Comments.BLL.DTOs;

namespace Comments.BLL.Services.Interfaces;

public interface ICommentsService
{
    public Task AddComment(CommentDto commentDto);
    public Task<IEnumerable<CommentDto>> GetCommentsByProductId(int productId);
    public Task DeleteComment(int id);
}