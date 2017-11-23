using System;
using System.Collections.Generic;

namespace Magenic.Kanban.Api.Models
{
    public partial class Board
    {
        public Board()
        {
            BoardTasks = new HashSet<BoardTask>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BoardTask> BoardTasks { get; set; }
    }
}
