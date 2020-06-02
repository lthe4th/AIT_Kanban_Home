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
    public class MemosRepo : BaseRepo, IMemosRepo
    {
        public bool DelMemos(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("id", id);
            var result = SqlMapper.ExecuteScalar<bool>(con, "delete_memos", param: p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IList<Memos> MemosList()
        {
            var Memos = SqlMapper.Query<Memos>(con, "get_memos", commandType: CommandType.StoredProcedure).ToList();
            return Memos;
        }

        public Memos NewMemos(Request_Memos model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@content", model.content);
            var modedDes = SqlMapper.Query<Memos>(con, "new_memos", param: p, commandType: CommandType.StoredProcedure).First();
            return modedDes;
        }
    }
}