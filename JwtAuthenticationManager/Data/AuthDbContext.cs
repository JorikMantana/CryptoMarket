using JwtAuthenticationManager.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthenticationManager.Data;

public class AuthDbContext : DbContext
{
    public DbSet<UserAccount> UserAccounts { get; set; }

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}