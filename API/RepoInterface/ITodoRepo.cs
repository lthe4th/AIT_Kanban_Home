using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;

namespace RepoInterface
{
    public interface ITodoRepo
    {
        IEnumerable<Todo> Todos(int id);
        Todo NewTodo(NewTodo model);
        Todo ModTodo(ModTodo model);
        bool DeleteTodo(int Id);
        bool DeleteAllTodo(DeleteAllTodo model);
    }
}