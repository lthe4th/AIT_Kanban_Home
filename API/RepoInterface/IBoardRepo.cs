using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;

namespace RepoInterface
{
    public interface IBoardRepo
    {
        IEnumerable<Board> Boards();
        Board NewBoard(NewBoard model);
        Board ModBoard(Modboard model);
        bool DeleteBoard(int Id);
        bool ClearAll();
    }
}