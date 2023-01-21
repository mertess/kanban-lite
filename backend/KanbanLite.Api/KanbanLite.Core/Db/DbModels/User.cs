using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Db.DbModels
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public IEnumerable<Board>? Boards { get; set; }
        public IEnumerable<Task>? Tasks { get; set;}
    }
}
