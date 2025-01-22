using Comments.BLL.DTOs;
using Comments.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comments.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CommentsController : Controller
{
    private readonly ICommentsService _commentsService;

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateComment(CommentDto commentDto)
    {
        await _commentsService.AddComment(commentDto);
        
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsByProductId(int productId)
    {
        var  comments = await _commentsService.GetCommentsByProductId(productId);
        
        return Ok(comments);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<ActionResult> DeleteComment(int commentId)
    {
        await _commentsService.DeleteComment(commentId);
        return Ok();
    }
}