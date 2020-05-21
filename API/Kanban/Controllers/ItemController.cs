using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using ServicesInterface;

namespace Kanban.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices ser;

        public ItemController(IItemServices ser)
        {
            this.ser = ser;
        }
        [HttpGet]
        [Route("api/items/{Id}")]
        public IEnumerable<Item> Items(int Id)
        {
            return this.ser.Items(Id);
        }
        [HttpPost]
        [Route("api/items/NewItem")]
        public Item NewItem([FromBody] newitem model){
            return this.ser.NewItem(model);
        }
        // [HttpPut("{id}")]
        // [HttpDelete("{id}")]
    }
}