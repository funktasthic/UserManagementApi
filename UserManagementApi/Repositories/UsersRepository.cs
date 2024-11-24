using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Exceptions;
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
    public async Task<User?> CreateUser(User user)
    {
        var existingUser = await dbSet.FirstOrDefaultAsync(u => u.Email == user.Email && u.IsActive == true);

        if (existingUser != null)
        {
            throw new DuplicateUserException("Email already in use");
        }

        dbSet.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteUser(string id)
    {
        var user = await dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);

        if (user == null)
        {
            return false;
        }

        user.IsActive = false;
        await context.SaveChangesAsync();

        return true;
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
