using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Request;
using Models.Response;

namespace RepoInterface
{
    public interface IItemRepo
    {
        
        IEnumerable<Item> Items(int Id);
        Item NewItem(newitem model);
        Item ModItem(ModItem model);
        bool DeleteItem(int Id);
        int CalculatedPercent(int Id);
        bool DeleteAllItem(DeleteAllItem model);
    }
}