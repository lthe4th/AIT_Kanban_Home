using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Request
{
    public class NewTodo
    {
        public int boardid { get; set; }
        public string name { get; set; }
    }
}