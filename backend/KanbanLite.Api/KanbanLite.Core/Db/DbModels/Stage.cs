using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Db.DbModels
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Board? Board { get; set; }
        public int BoardId { get; set; }

        public IEnumerable<Task>? Tasks { get; set; }
    }
}
