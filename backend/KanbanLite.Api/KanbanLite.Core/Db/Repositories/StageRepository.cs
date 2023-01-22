using KanbanLite.Core.Db.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Db.Repositories
{
    public class StageRepository : BaseRepository<Stage>
    {
        public StageRepository(KanbanLiteDbContext dbContext) : base(dbContext)
        {
        }
    }
}
