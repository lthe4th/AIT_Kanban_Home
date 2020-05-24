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
        [Route("api/items/new")]
        public Item NewItem([FromBody] newitem model){
            return this.ser.NewItem(model);
        }
        [HttpPut]
        [Route("api/items/mod")]
        public Item ModItem([FromBody] ModItem model){
            return this.ser.ModItem(model);
        }
        [HttpDelete]
        [Route("api/items/delete/{Id}")]
        public bool DeleteItem(int Id){
            return this.ser.DeleteItem(Id);
        }

        [HttpDelete]
        [Route("api/items/delete/all")]
        public bool DeleteAllItem([FromBody] DeleteAllItem model){
            return this.ser.DeleteAllItem(model);
        }
    }
}