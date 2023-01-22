using KanbanLite.Core.Db.DbModels;
using System.Linq.Expressions;

namespace KanbanLite.Core.Db.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        void Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> where);
    }
}
