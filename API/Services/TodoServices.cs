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
        public bool DeleteTodo(int Id)
        {
            throw new NotImplementedException();
        }

        public Todo ModTodo(ModTodo model)
        {
            throw new NotImplementedException();
        }

        public Todo NewTodo(NewTodo model)
        {
            return this.repo.NewTodo(model);
        }

        public IEnumerable<Todo> Todos()
        {
            return this.repo.Todos();
        }
    }
}