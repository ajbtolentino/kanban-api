using System;

namespace Magenic.Kanban.Api.Models
{
    public partial class BoardTask
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }
        public Guid TaskId { get; set; }
        public bool IsActive { get; set; }

        public Board Board { get; set; }
        public Task Task { get; set; }
    }
}
