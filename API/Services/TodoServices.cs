using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;
using RepoInterface;
using ServicesInterface;

namespace Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ITodoRepo repo;

        public TodoServices(ITodoRepo repo)
        {
            this.repo = repo;
        }

        public bool DeleteAllTodo(DeleteAllTodo model)
        {
            return this.repo.DeleteAllTodo(model);
        }

        public bool DeleteTodo(int Id)
        {
            return this.repo.DeleteTodo(Id);
        }

        public Todo ModTodo(ModTodo model)
        {
            return this.repo.ModTodo(model);
        }

        public Todo NewTodo(NewTodo model)
        {
            return this.repo.NewTodo(model);
        }

        public IEnumerable<Todo> Todos(int Id)
        {
            return this.repo.Todos(Id);
        }
    }
}