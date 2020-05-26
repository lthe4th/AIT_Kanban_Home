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
        [Route("api/boards/new")]

        public Board NewBoard([FromBody] NewBoard model){
            return this.ser.NewBoard(model);
        }
        [HttpPut]
        [Route("api/boards/mod")]
        public Board ModBoard([FromBody] Modboard model){
            return this.ser.ModBoard(model);
        }
        [HttpDelete]
        [Route("api/boards/delete/{Id}")]
        public bool DeleteBoard(int Id){
            return this.ser.DeleteBoard(Id);
        }

        [HttpDelete]
        [Route("api/boards/delete/clear/everything")]
        public bool ClearAll(){
            return this.ser.ClearAll();
        }
    }
}