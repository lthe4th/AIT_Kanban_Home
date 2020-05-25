using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Repo;
using Services;
using ServicesInterface;

namespace Kanban.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IBoardServices board;

        public ReportController(IHostingEnvironment hostingEnvironment, IBoardServices board)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.board = board;
        }


        [HttpGet]
        [Route("api/export")]
        public string ExportCustomer()
        {
            string rootFolder = hostingEnvironment.WebRootPath;
            string fileName = @"File1.xlsx";
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                IEnumerable<Board> boardlist = board.Boards();
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("board");
                int totalRow = boardlist.Count();
                worksheet.Cells[1, 1].Value = "Board Id";
                worksheet.Cells[1, 2].Value = "Board Name";
                int row = 2;
                foreach (var item in boardlist)
                {
                    worksheet.Cells[row, 1].Value = item.Id;
                    worksheet.Cells[row, 2].Value = item.BoardName;
                    row++;
                }
                package.Save();
            }
            return " Customer list has been exported successfully";
        }
    }
}