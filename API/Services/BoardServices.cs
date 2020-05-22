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

        public bool ClearAll()
        {
            return this.repo.ClearAll();
        }

        public bool DeleteBoard(int Id)
        {
            return this.repo.DeleteBoard(Id);
        }

        public Board ModBoard(Modboard model)
        {
            return this.repo.ModBoard(model);
        }

        public Board NewBoard(NewBoard model)
        {
            return this.repo.NewBoard(model);
        }
    }
}