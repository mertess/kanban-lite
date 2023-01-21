using KanbanLite.Core.Db.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KanbanLite.Core.Db
{
    public class KanbanLiteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<DbModels.Task> Tasks { get; set; }

        public KanbanLiteDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
