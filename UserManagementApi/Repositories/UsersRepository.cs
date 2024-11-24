using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Repositories.Interfaces;

namespace UserManagementApi.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    private readonly Expression<Func<User, bool>> softDeleteFilter = x => x.IsActive == true;

    public UsersRepository(DataContext context) : base(context) { }

    public async Task<User?> GetByEmail(string email)
    {
        return await dbSet
            .Where(softDeleteFilter)
            .FirstOrDefaultAsync(x => x.Email == email);
    }
    public Task<User?> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllUsers(int page, int pageSize)
    {
        return await dbSet.Where(softDeleteFilter).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<User?> GetUserById(string id)
    {
        return await dbSet.Where(softDeleteFilter).FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<User?> UpdateUser(string id, User user)
    {
        throw new NotImplementedException();
    }
}
