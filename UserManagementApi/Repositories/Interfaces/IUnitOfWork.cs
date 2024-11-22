using UserManagementApi.Repositories.Interfaces;

namespace UserManagementApi.Repositories.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Obtener usuarios de la base de datos segun el metodo
    /// </summary>
    public IUsersRepository UsersRepository { get; }
    
}