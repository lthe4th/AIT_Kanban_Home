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
        [Route("api/todos/board/{Id}")]
        public IEnumerable<Todo> Todos(int Id)
        {
            return this.ser.Todos(Id);
        }
        [HttpPost]
        [Route("api/todos/new")]
        public Todo NewToDo([FromBody] NewTodo model)
        {
            return this.ser.NewTodo(model);
        }
        [HttpPut]
        [Route("api/todos/mod")]
        public Todo ModTodo([FromBody] ModTodo model)
        {
            return this.ser.ModTodo(model);
        }
        [HttpDelete]
        [Route("api/todos/delete/{Id}")]
        public bool DeleteTodo(int Id)
        {
            return this.ser.DeleteTodo(Id);
        }

        [HttpDelete]
        [Route("api/todos/delete/all")]
        public bool DeleteAllTodo([FromBody] DeleteAllTodo model){
            return this.ser.DeleteAllTodo(model);
        }   
    }
}