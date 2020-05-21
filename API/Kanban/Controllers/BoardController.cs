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
    public class BoardController : ControllerBase
    {
        private readonly IBoardServices ser;

        public BoardController(IBoardServices ser)
        {
            this.ser = ser;
        }
        [HttpGet]
        [Route("api/boards")]

        public IEnumerable<Board> Boards() {
            return this.ser.Boards();
        }
        [HttpPost]
        [Route("api/boards/NewBoard")]

        public Board NewBoard([FromBody] NewBoard model){
            return this.ser.NewBoard(model);
        }
        // [HttpPut("{id}")]
        // [HttpDelete("{id}")]
    }
}