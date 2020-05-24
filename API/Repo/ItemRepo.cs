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

        public bool DeleteAllItem(DeleteAllItem model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@todoid",model.todoid);
            bool result = SqlMapper.ExecuteScalar<bool>(con,"dropallitem",param:p,commandType:CommandType.StoredProcedure);
            return result;
        }

        public bool DeleteItem(int Id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",Id);
            bool result = SqlMapper.ExecuteScalar<bool>(con,"deleteitem",param:p,commandType:CommandType.StoredProcedure);
            return result;
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
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id",model.Id);
            p.Add("@name",model.ItemName);
            p.Add("@status",model.isfinished);

            Item modedItem = SqlMapper.Query<Item>(con, "moditem",param:p,commandType:CommandType.StoredProcedure).First();
            return modedItem;
        }

        public Item NewItem(newitem model)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@TodoId",model.todoid);
            p.Add("@Name",model.ItemName);
            Item newitem = SqlMapper.Query<Item>(con,"NewItem",param:p,commandType:CommandType.StoredProcedure).First();;
            return newitem;
        }
    }
}