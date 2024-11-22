
namespace UserManagementApi.Repositories.Interfaces;

public interface IUnitOfWork
{

    public IUsersRepository UsersRepository { get; }
    
}