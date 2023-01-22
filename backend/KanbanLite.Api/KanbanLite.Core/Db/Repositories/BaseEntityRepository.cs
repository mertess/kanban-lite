using KanbanLite.Core.Db.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace KanbanLite.Core.Db.Repositories
{
    public abstract class BaseRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            if(entity.CreatedAtUtc == default)
                entity.CreatedAtUtc = DateTime.UtcNow;

            _entities.Add(entity);
        }

        public void Create(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
                Delete(entity);
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return _entities.FirstOrDefault(where);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _entities.Where(where);
        }

        public void Update(TEntity entity)
        {
            static bool IsOwnedEntityChanged(EntityEntry entry) =>
                entry.State == EntityState.Modified || entry.State == EntityState.Added;

            static bool AnyOwnedEntityPropsChanged(IEnumerable<ReferenceEntry> references) => references.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (IsOwnedEntityChanged(r.TargetEntry) || AnyOwnedEntityPropsChanged(r.TargetEntry.References)));

            static bool IsEntityStateModified(EntityEntry entry) =>
                entry.State == EntityState.Modified || AnyOwnedEntityPropsChanged(entry.References);

            var entityEntry = _dbContext.Entry(entity);
            if (IsEntityStateModified(entityEntry) && !entityEntry.Property(nameof(BaseEntity.UpdatedAtUtc)).IsModified)
                entity.UpdatedAtUtc = DateTimeOffset.UtcNow;
            else if (entityEntry.State == EntityState.Detached)
                throw new InvalidOperationException("Can't save detached entity.");
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
    }
}
