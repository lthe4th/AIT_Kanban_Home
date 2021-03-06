using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;

namespace RepoInterface
{
    public interface IMemosRepo
    {
        IList<Memos> MemosList();
        Memos NewMemos(Request_Memos model);
        bool DelMemos(int id);
    }
}