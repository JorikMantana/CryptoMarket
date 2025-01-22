using Comments.DAL.Data;
using Comments.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Comments.DAL.Repositories.Interfaces;

public class CommentsRepository : ICommentsRepository
{
    private readonly ApplicationDbContext _context;

    public CommentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddComment(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> GetCommentsByProductId(int productId)
    {
        return await _context.Comments.Where(c => c.ProductId == productId).ToListAsync();
    }

    public async Task DeleteComment(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}