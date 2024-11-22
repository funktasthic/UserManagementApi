using UserManagementApi.Data;
using UserManagementApi.Repositories.Interfaces;

namespace UserManagementApi.Services;

public class UnitOfWork : IUnitOfWork
{
    private IUsersRepository _usersRepository = null!;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    private readonly DataContext _context;
    private bool _disposed = false;


    public IUsersRepository UsersRepository
    {
        get
        {
            _usersRepository ??= new UsersRepository(_context);
            return _usersRepository;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}