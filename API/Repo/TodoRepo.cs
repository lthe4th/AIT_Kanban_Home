using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models.Request;
using Models.Response;
using RepoInterface;
namespace Repo
{
    public class TodoRepo : BaseRepo,ITodoRepo
    {
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
            DynamicParameters p = new DynamicParameters();
            p.Add("@BoardId",model.boardid);
            p.Add("@Name",model.name);
            Todo newtodo = SqlMapper.Query<Todo>(con, "NewTodo",param:p, commandType : CommandType.StoredProcedure).First();
            return newtodo;
        }

        public IEnumerable<Todo> Todos()
        {
            
            IEnumerable<Todo> todos = SqlMapper.Query<Todo>(con,"gettodos",commandType: CommandType.StoredProcedure).ToList();
            return todos;
        }
    }
}