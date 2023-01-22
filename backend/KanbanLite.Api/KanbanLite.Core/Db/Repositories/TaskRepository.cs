using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanbanLite.Core.Db.Repositories
{
    public class TaskRepository : BaseRepository<DbModels.Task>
    {
        public TaskRepository(KanbanLiteDbContext dbContext) : base(dbContext)
        {
        }
    }
}
