using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using RepoInterface;
using ServicesInterface;

namespace Kanban.Controllers
{
    [ApiController]
    public class MemosController : ControllerBase
    {
        private readonly IMemosServices ser;

        public MemosController(IMemosServices ser)
        {
            this.ser = ser;
        }
        [HttpDelete]
        [Route("api/memos/delete/{id}")]
        public bool DelMemos(int id)
        {
            return this.ser.DelMemos(id);
        }

        [HttpGet]
        [Route("api/memos")]
        public IList<Memos> MemosList()
        {
            return this.ser.MemosList();
        }

        [HttpPost]
        [Route("api/memos/new")]

        public Memos NewMemos([FromBody] Request_Memos model)
        {
            return this.ser.NewMemos(model);
        }
    }
}