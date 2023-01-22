namespace KanbanLite.Core.Db
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
