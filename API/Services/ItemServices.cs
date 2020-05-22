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
    public class ItemServices : IItemServices
    {
        private readonly IItemRepo repo;

        public ItemServices(IItemRepo repo)
        {
            this.repo = repo;
        }

        public int CalculatedPercent(int Id)
        {
            return this.repo.CalculatedPercent(Id);
        }

        public bool DeleteAllItem(DeleteAllItem model)
        {
            return this.repo.DeleteAllItem(model);
        }

        public bool DeleteItem(int Id)
        {
            return this.repo.DeleteItem(Id);
        }

        public IEnumerable<Item> Items(int Id)
        {
            return this.repo.Items(Id);
        }

        public Item ModItem(ModItem model)
        {
            return this.repo.ModItem(model);
        }

        public Item NewItem(newitem model)
        {
            return this.repo.NewItem(model);
        }
    }
}