using System.Linq.Expressions;
using auth_servicetarea4_arquitectura_de_sistemas.Repositories;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Repositories.Interfaces;

namespace UserManagementApi.Repositories.Interfaces;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{

        // Filtro para valdiar si es que el usuario esta activo IsActive = true
        private readonly Expression<Func<User, bool>> softDeleteFilter = x => x.IsActive == true;

        public UsersRepository(DataContext context) : base(context) { }

        public async Task<List<User>> GetAll()
        {
            var users = await dbSet.ToListAsync();
            return users;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await dbSet
                        .Where(softDeleteFilter)
                        .FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
}