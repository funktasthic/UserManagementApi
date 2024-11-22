using UserManagementApi.Models;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{
    public Task<List<User>> GetAll();
}