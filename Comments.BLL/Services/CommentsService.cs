using Comments.BLL.DTOs;
using Comments.BLL.Services.Interfaces;
using Comments.DAL.Models;
using Comments.DAL.Repositories.Interfaces;
using Mapster;

namespace Comments.BLL.Services;

public class CommentsService : ICommentsService
{
    private readonly ICommentsRepository _commentsRepository;

    public CommentsService(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }
    
    public async Task AddComment(CommentDto commentDto)
    {
        var comment = commentDto.Adapt<Comment>();
        
        await _commentsRepository.AddComment(comment);
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsByProductId(int productId)
    {
        var comments = await _commentsRepository.GetCommentsByProductId(productId);
        
        return comments.Adapt<IEnumerable<CommentDto>>();
    }

    public async Task DeleteComment(int id)
    {
        await _commentsRepository.DeleteComment(id);
    }
}