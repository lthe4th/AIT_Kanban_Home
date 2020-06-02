using System.Diagnostics;
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
    public class MemosServices : IMemosServices
    {
        private readonly IMemosRepo repo;

        public MemosServices(IMemosRepo repo)
        {
            this.repo = repo;
        }
        public bool DelMemos(int id)
        {
            return this.repo.DelMemos(id);
        }

        public IList<Memos> MemosList()
        {
            return this.repo.MemosList();
        }

        public Memos NewMemos(Request_Memos model)
        {
            return this.repo.NewMemos(model);
        }
    }
}