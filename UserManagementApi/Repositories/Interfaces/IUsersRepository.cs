using UserManagementApi.Models;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{
    /// <summary>
    /// Encuentra el primer usuario en la base de datos que tenga el estado IsActive = true según el  proporcionado.
    /// </summary>
    /// <param name="email"></param>
    /// <returns>User o Null</returns>
    public Task<User?> GetByEmail(string email);
    public Task<IEnumerable<User>> GetAllUsers(int page, int pageSize);
    public Task<User?> GetUserById(string id);
    Task<User?> CreateUser(User user);
    Task<User?> UpdateUser(string id, User user);
    Task<bool> DeleteUser(string id);
}