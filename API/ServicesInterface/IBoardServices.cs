using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;
using RepoInterface;

namespace ServicesInterface
{
    public interface IBoardServices
    {
        IEnumerable<Board> Boards();
        Board NewBoard(NewBoard model);
        Board ModBoard(Modboard model);
        bool DeleteBoard(int Id);
    }
}