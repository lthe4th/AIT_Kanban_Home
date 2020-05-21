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
    public class ItemRepo : BaseRepo, IItemRepo
    {
        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> Items(int Id)
        {

            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",Id);

            IEnumerable<Item> items = SqlMapper.Query<Item>(con,"getitems", commandType: CommandType.StoredProcedure, param:p).ToList();
            return items;
        }

        public Item ModItem(ModItem model)
        {
            throw new NotImplementedException();
        }

        public Item NewItem(newitem model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@TodoId",model.todoid);
            p.Add("@Name",model.name);
            Item newitem = SqlMapper.Query<Item>(con,"NewItem",param:p,commandType:CommandType.StoredProcedure).First();;
            return newitem;
        }
    }
}