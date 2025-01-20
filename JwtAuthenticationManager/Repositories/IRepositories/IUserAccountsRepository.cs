using JwtAuthenticationManager.Models;

namespace JwtAuthenticationManager.Repositories.IRepositories;

public interface IUserAccountsRepository
{
    public Task<IEnumerable<UserAccount>> GetAllUsers();
    public Task<UserAccount> GetUserByUserName(string UserName);
    public Task<UserAccount> GetUserByUserNameAndPassword(string UserName, string Password);
    public Task AddUser(UserAccount userAccount);
    public Task UpdateUser(UserAccount userAccount);
    public Task DeleteUser(string UserName);
}