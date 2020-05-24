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

        public bool ClearAll()
        {
            bool result = SqlMapper.ExecuteScalar<bool>(con,"dropallboard",commandType:CommandType.StoredProcedure);
            return result;
        }

        public bool DeleteBoard(int Id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",Id);
            bool result = SqlMapper.ExecuteScalar<bool>(con,"deleteboard",param:p, commandType:CommandType.StoredProcedure);
            return result;
        }

        public Board ModBoard(Modboard model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",model.Id);
            p.Add("@name",model.BoardName);

            Board ModedBoard = SqlMapper.Query<Board>(con,"modboard",param:p,commandType:CommandType.StoredProcedure).First();
            return ModedBoard;
        }

        public Board NewBoard(NewBoard model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@name", model.BoardName);
            Board newboard = SqlMapper.Query<Board>(con, "NewBoard", param: p, commandType: CommandType.StoredProcedure).First();
            return newboard;
        }
    }
}