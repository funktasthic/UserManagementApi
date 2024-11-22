using UserManagementApi.Models;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{

    /// <summary>
    /// Retorna todos los usuarios en la base de datos que tenga el estado IsActive = true
    /// </summary>
    /// <returns></returns>
    public Task<List<User>> GetAll();

    /// <summary>
    /// Encuentra el primer usuario en la base de datos que tenga el estado IsActive = true según el  proporcionado.
    /// </summary>
    /// <param name="email"></param>
    /// <returns>User o Null</returns>
    public Task<User?> GetByEmail(string email);
}