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
        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> Items(int Id)
        {
            return this.repo.Items(Id);
        }

        public Item ModItem(ModItem model)
        {
            throw new NotImplementedException();
        }

        public Item NewItem(newitem model)
        {
            return this.repo.NewItem(model);
        }
    }
}