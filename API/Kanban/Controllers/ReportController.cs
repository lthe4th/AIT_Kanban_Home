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
using OfficeOpenXml.Style;
using System.Drawing;

namespace Kanban.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IBoardServices board;
        private readonly ITodoServices todo;
        private readonly IItemServices item;

        [Obsolete]
        public ReportController(IHostingEnvironment hostingEnvironment, IBoardServices board, ITodoServices todo, IItemServices item)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.board = board;
            this.todo = todo;
            this.item = item;
        }


        [HttpGet]
        [Route("api/export")]
        public async Task<string> ExportReport()
        {
            string rootFolder = hostingEnvironment.WebRootPath;
            string fileName = "BoardReport.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(rootFolder, fileName));
            }
            await Task.Yield();
            var BoardList = board.Boards(); ;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("board");
                // worksheet.Cells.LoadFromCollection(BoardList,true);
                int totalRow = BoardList.Count();
                worksheet.Cells[1, 1].Value = "Board Name";
                worksheet.Cells[1, 2].Value = "Task Name";
                worksheet.Cells[1, 3].Value = "Check List Item";
                worksheet.Cells[1, 4].Value = "Finished";
                FillBackGround(worksheet, 1, 1, 1, true);
                FillBackGround(worksheet, 2, 2, 5, true);

                int row = 3;
                foreach (var BoardItem in BoardList)
                {
                    worksheet.Cells[row, 1].Value = BoardItem.BoardName;
                    FillBackGround(worksheet, row, row, 1, true);
                    var TodoList = todo.Todos(BoardItem.Id);
                    foreach (var TodoItem in TodoList)
                    {
                        worksheet.Cells[row, 2].Value = TodoItem.TodoName;
                        FillBackGround(worksheet,row,row,1,true);
                        FillBackGround(worksheet, row, 2, 3, false);
                        // worksheet.Cells[row,2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182,196,162));
                        var ItemList = item.Items(TodoItem.Id);
                        foreach (var item in ItemList)
                        {
                            worksheet.Cells[row, 3].Value = item.ItemName;
                            FillBackGround(worksheet, row, row, 1, true);
                            FillBackGround(worksheet, row, 2, 3, false);
                            if (item.isfinished)
                            {
                                worksheet.Cells[row, 4].Value = "Yes";
                                FillBackGround(worksheet, row, 3, 4, false);
                            }
                            else
                            {
                                worksheet.Cells[row, 4].Value = "No";
                                FillBackGround(worksheet, row, 3, 2, false);
                            }
                            row++;
                            FillBackGround(worksheet, row, row, 1, true);
                        }
                        row++;
                        FillBackGround(worksheet,row,row,5,true);
                    }
                    row++;
                }
                using (var range = worksheet.Cells["A1:D" + (row - 1) + ""])
                {
                    // Set PatternType
                    // range.Style.Fill.PatternType = ;
                    // Set Màu cho Background
                    // range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb);
                    // Canh giữa cho các text
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    // Set Font cho text  trong Range hiện tại
                    range.Style.Font.SetFromFont(new Font("Arial", 16));
                    using (var range1 = worksheet.Cells["A1:D1"])
                    {
                        range1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        range1.Style.Font.SetFromFont(new Font("Arial", 20, FontStyle.Bold));



                        // range1.Style.
                    }
                    // Set Border
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    // Set màu ch Border
                    // range.Style.Border.Bottom.Color.SetColor(Color.LightBlue);
                    // worksheet.Cells.AutoFitColumns();
                    worksheet.DefaultColWidth = 45;
                    worksheet.Cells.Style.WrapText = true;

                }

                package.Save();
            }
            return downloadUrl;
        }
        [HttpDelete]
        [Route("/api/ashdjk12iou37eu9as7d9aysuidy162e3uiyakusdtghzjxgidtas8e5618e6asizdty91")]
        public bool FillBackGround(ExcelWorksheet worksheet, int rowa, int rowb, int color, bool _case)
        {
            if (_case)
            {
                string Position = "A" + rowa + ":D" + rowb;
                worksheet.Cells[Position].Style.Fill.PatternType = ExcelFillStyle.Solid;
                switch (color)
                {
                    case 1:
                        {
                            worksheet.Cells[Position].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220, 226, 189));
                            return true;
                        };
                    case 2:
                        {
                            worksheet.Cells[Position].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(124, 108, 119));
                            return true;
                        };
                    case 3:
                        {
                            worksheet.Cells[Position].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182, 196, 162));
                            return true;
                        };
                    case 4:
                        {
                            worksheet.Cells[Position].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(147, 192, 164));
                            return true;
                        };
                    case 5:
                        {
                            worksheet.Cells[Position].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(142, 155, 144));
                            return true;
                        }
                    default:
                        {
                            return false;
                        }
                }
            }
            else
            {
                worksheet.Cells[rowa, rowb].Style.Fill.PatternType = ExcelFillStyle.Solid;
                switch (color)
                {
                    case 1:
                        {
                            worksheet.Cells[rowa, rowb].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220, 226, 189));
                            return true;
                        };
                    case 2:
                        {
                            worksheet.Cells[rowa, rowb].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(124, 108, 119));
                            return true;
                        };
                    case 3:
                        {
                            worksheet.Cells[rowa, rowb].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182, 196, 162));
                            return true;
                        };
                    case 4:
                        {
                            worksheet.Cells[rowa, rowb].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(147, 192, 164));
                            return true;
                        };
                    case 5:
                        {
                            worksheet.Cells[rowa, rowb].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(142, 155, 144));
                            return true;
                        }
                    default:
                        {
                            return false;
                        }
                }

            }

            // range1.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220,226,189));
            // range1.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(124,108,119));
            // range1.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182,196,162));
            // range1.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(147,192,164));
            // range1.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(142,155,144));
        }
    }
}