using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Db.DbModels
{
    public class Board : BaseEntity
    {
        public string Name { get; set; } = null!;

        public User? User { get; set; }
        public int UserId { get; set; }

        public IEnumerable<Stage>? Stages { get; set; }
    }
}
