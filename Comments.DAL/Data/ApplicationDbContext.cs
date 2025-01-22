using Comments.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Comments.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}