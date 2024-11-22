using UserManagementApi.Models;
using UserManagementApi.Repositories.Interfaces;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{

    public Task<List<User>> GetAll();
    
    public Task<User?> GetByEmail(string email);
}