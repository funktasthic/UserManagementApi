using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.Repositories.Interfaces;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    private readonly Expression<Func<User, bool>> softDeleteFilter = x => x.IsActive == true;

    public UsersRepository(DataContext context) : base(context) { }

    public async Task<List<User>> GetAll()
    {
        var users = await dbSet.ToListAsync();
        return users;
    }
}