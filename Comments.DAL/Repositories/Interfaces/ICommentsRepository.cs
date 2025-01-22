using Comments.DAL.Models;

namespace Comments.DAL.Repositories.Interfaces;

public interface ICommentsRepository
{
    public Task AddComment(Comment comment);
    public Task<IEnumerable<Comment>> GetCommentsByProductId(int productId);
    public Task DeleteComment(int id);
}