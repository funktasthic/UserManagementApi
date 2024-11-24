using UserManagementApi.Models;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{
    public Task<IEnumerable<User>> GetAllUsers(int page, int pageSize);
    public Task<User?> GetUserById(string id);
    Task<User?> CreateUser(User user);
    Task<User?> UpdateUser(string id, User user);
    Task<bool> DeleteUser(string id);
    public Task<User?> GetByEmail(string email);
}