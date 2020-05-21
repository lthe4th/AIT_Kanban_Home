using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Response
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public bool isfinished  { get; set; }
        public int todoid { get; set; }
    }
}