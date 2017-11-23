using System;
using System.Collections.Generic;

namespace Magenic.Kanban.Api.Models
{
    public partial class Task
    {
        public Task()
        {
            BoardTasks = new HashSet<BoardTask>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public ICollection<BoardTask> BoardTasks { get; set; }
    }
}
