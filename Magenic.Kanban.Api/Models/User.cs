using System;
using System.Collections.Generic;

namespace Magenic.Kanban.Api.Models
{
    public partial class User
    {
        public User()
        {
            Task = new HashSet<Task>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
