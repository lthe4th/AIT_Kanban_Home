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
        public bool DeleteAllTodo(DeleteAllTodo model)
        {
            DynamicParameters p  = new DynamicParameters();
            p.Add("@boardid",model.BoardId);
            bool result = SqlMapper.ExecuteScalar<bool>(con, "dropalltodo",param:p,commandType:CommandType.StoredProcedure);
            return result;
        }

        public bool DeleteTodo(int Id)
        {
           DynamicParameters p = new DynamicParameters();
            p.Add("@Id",Id);
            bool result = SqlMapper.ExecuteScalar<bool>(con,"deletetodo",param:p,commandType:CommandType.StoredProcedure);
            return result;
        }

        public Todo ModTodo(ModTodo model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",model.Id);
            p.Add("@name",model.TodoName);
            p.Add("@prio",model.Prio);
            p.Add("@deadline",model.Deadline);
            p.Add("@deadlinestatus",model.DeadlineStatus);
            p.Add("@boardid",model.BoardId);

            Todo modedtodo = SqlMapper.Query<Todo>(con,"modtodo", param:p, commandType:CommandType.StoredProcedure).First();
            return modedtodo;

        }

        public Todo NewTodo(NewTodo model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@BoardId",model.boardid);
            p.Add("@Name",model.TodoName);
            Todo newtodo = SqlMapper.Query<Todo>(con, "NewTodo",param:p, commandType : CommandType.StoredProcedure).First();
            return newtodo;
        }

        public IEnumerable<Todo> Todos(int Id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",Id);

            IEnumerable<Todo> todos = SqlMapper.Query<Todo>(con,"todosid",commandType: CommandType.StoredProcedure, param:p).ToList();
            return todos;
        }
    }
}