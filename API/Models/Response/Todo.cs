using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Response
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public int Prio { get; set; }
        public DateTime Deadline { get; set; }
        public bool DeadlineStatus { get; set; }
        public int BoardId { get; set; }
    }
}