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
    public class BoardRepo : BaseRepo, IBoardRepo
    {
        public IEnumerable<Board> Boards()
        {
            IList<Board> boards = SqlMapper.Query<Board>(con, "getboards", commandType: CommandType.StoredProcedure).ToList();
            return boards;
        }

        public bool DeleteBoard(int Id)
        {
            throw new NotImplementedException();
        }

        public Board ModBoard(Modboard model)
        {
            throw new NotImplementedException();
        }

        public Board NewBoard(NewBoard model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@name", model.Name);
            Board newboard = SqlMapper.Query<Board>(con, "NewBoard", param: p, commandType: CommandType.StoredProcedure).First();
            return newboard;
        }
    }
}