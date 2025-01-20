using JwtAuthenticationManager.Data;
using JwtAuthenticationManager.Models;
using JwtAuthenticationManager.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthenticationManager.Repositories;

public class UserAccountsRepository : IUserAccountsRepository
{
    private readonly AuthDbContext _context;

    public UserAccountsRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserAccount>> GetAllUsers()
    {
        return await _context.UserAccounts.ToListAsync();
    }

    public async Task<UserAccount> GetUserByUserName(string UserName)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == UserName);
    }

    public async Task<UserAccount> GetUserByUserNameAndPassword(string UserName, string Password)
    {
        var user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
        return user;
    }

    public async Task AddUser(UserAccount userAccount)
    {
        await _context.UserAccounts.AddAsync(userAccount);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(UserAccount userAccount)
    {
        _context.UserAccounts.Entry(userAccount).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(string UserName)
    {
        var user = await GetUserByUserName(UserName);
        _context.UserAccounts.Remove(user);

        await _context.SaveChangesAsync();
    }
}