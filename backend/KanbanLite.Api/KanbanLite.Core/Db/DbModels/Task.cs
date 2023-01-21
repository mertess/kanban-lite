using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Db.DbModels
{
    public class Task : BaseEntity
    {
        public string Name { get; set; } = null!;

        public User? User { get; set; }
        public int UserId { get; set; }

        public Board? Board { get; set; }
        public int BoardId { get; set; }
        
        public Stage? Stage { get; set; }
        public int StageId { get; set; }
    }
}
