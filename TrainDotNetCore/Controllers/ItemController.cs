using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainDotNetCore.Services;

namespace TrainDotNetCore.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly IItemService itemService;
        public ItemController(IItemService itemServiceTemp)
        {
            this.itemService = itemServiceTemp;
        }

        [HttpGet]
        public IActionResult GetItem()
        {
            return Content("No implement for now");
        }

        [HttpGet("ExportData")]
        public async Task<IActionResult> ExportData(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");

            string fileRealName = this.itemService.ExportItemDataToExcel(fileName);            

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", fileRealName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        [HttpGet("DowloadMultiItem")]
        public async Task<IActionResult> DowloadMultiItem(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");

            string fileRealName = this.itemService.ExportMultiItemData(fileName);

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", fileRealName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}