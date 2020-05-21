using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using ServicesInterface;

namespace Kanban.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices ser;

        public TodoController(ITodoServices ser)
        {
            this.ser = ser;
        }
        [HttpGet]
        [Route("api/todos")]
        public IEnumerable<Todo> Todos() {
            return this.ser.Todos();
        }
        [HttpPost]
        [Route("api/todos/NewTodo")]
        public Todo NewToDo([FromBody] NewTodo model){
            return this.ser.NewTodo(model);
        }
        // [HttpPut("{id}")]
        // [HttpDelete("{id}")]
    }
}