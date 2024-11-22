using System.Linq.Expressions;


namespace UserManagementApi.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");


        Task<TEntity?> GetByUUID(object uuid);


        Task<TEntity> Insert(TEntity entity);


        Task<TEntity> Update(TEntity entityToUpdate);
    }
}