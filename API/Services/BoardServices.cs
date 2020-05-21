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
    public class BoardServices : IBoardServices
    {
        private readonly IBoardRepo repo;

        public BoardServices(IBoardRepo repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Board> Boards()
        {
            return this.repo.Boards();
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
            return this.repo.NewBoard(model);
        }
    }
}