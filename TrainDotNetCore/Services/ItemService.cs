using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainDotNetCore.Models;

namespace TrainDotNetCore.Services
{
    public interface IItemService
    {
        string ExportItemDataToExcel(string fileNames);
    }

    public class ItemService : IItemService
    {
        public readonly PsmContext psmContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemService(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.psmContext = new PsmContext();
        }

        public string ExportItemDataToExcel(string fileNames)
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"" + fileNames + ".xlsx";

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {

                IList<Item> customerList = this.psmContext.Item.ToList();

                ExcelWorksheet worksheet; 

                bool found = false;
                foreach(ExcelWorksheet worksheetTemp in package.Workbook.Worksheets)
                {
                    if (worksheetTemp.Name.Equals("Item"))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    worksheet = package.Workbook.Worksheets.Add("Item " + new DateTime().ToString("YYYY-MM-dd H:mm:ss"));
                }
                else
                {
                    worksheet = package.Workbook.Worksheets.Add("Item");
                }

                int totalRows = customerList.Count();

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "CreatedBy";
                worksheet.Cells[1, 3].Value = "UpdatedBy";
                worksheet.Cells[1, 4].Value = "CreatedDate";
                worksheet.Cells[1, 5].Value = "UpdatedDate";
                worksheet.Cells[1, 6].Value = "Full saleText";
                worksheet.Cells[1, 7].Value = "ID L";
                worksheet.Cells[1, 8].Value = "ID w";
                worksheet.Cells[1, 9].Value = "ID H";
                worksheet.Cells[1, 10].Value = "FG L";
                worksheet.Cells[1, 11].Value = "FG w";
                worksheet.Cells[1, 12].Value = "AreaFG";
                worksheet.Cells[1, 13].Value = "WeightPerUnit";
                worksheet.Cells[1, 14].Value = "Color Full String";
                worksheet.Cells[1, 15].Value = "ItemCode";
                worksheet.Cells[1, 16].Value = "Mat No.";
                worksheet.Cells[1, 17].Value = "Mat Dec.";                
                worksheet.Cells[1, 18].Value = "PC Prefix";
                worksheet.Cells[1, 19].Value = "PC Running";
                worksheet.Cells[1, 20].Value = "PC Suffix";
                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 1].Value = customerList[i].Id;
                    worksheet.Cells[row, 2].Value = customerList[i].CreatedBy;
                    worksheet.Cells[row, 3].Value = customerList[i].UpdatedBy;
                    worksheet.Cells[row, 4].Value = customerList[i].CreatedDate;
                    worksheet.Cells[row, 5].Value = customerList[i].UpdatedDate;
                    worksheet.Cells[row, 6].Value = customerList[i].FullSaleText;
                    worksheet.Cells[row, 7].Value = customerList[i].IdLength;
                    worksheet.Cells[row, 8].Value = customerList[i].IdWidth;
                    worksheet.Cells[row, 9].Value = customerList[i].IdHeight;
                    worksheet.Cells[row, 10].Value = customerList[i].FgSheetLength;
                    worksheet.Cells[row, 11].Value = customerList[i].FgSheetWidth;
                    worksheet.Cells[row, 12].Value = customerList[i].Areafg;
                    worksheet.Cells[row, 13].Value = customerList[i].WeightPerUnit;
                    worksheet.Cells[row, 14].Value = customerList[i].ColorFullString;
                    worksheet.Cells[row, 15].Value = customerList[i].ItemCode;
                    worksheet.Cells[row, 16].Value = customerList[i].MaterialNumber;
                    worksheet.Cells[row, 17].Value = customerList[i].MaterialDescription;
                    worksheet.Cells[row, 18].Value = customerList[i].PcCodePrefix;
                    worksheet.Cells[row, 19].Value = customerList[i].PcCodeRunning;
                    worksheet.Cells[row, 20].Value = customerList[i].PcCodeSuffix;
                    i++;
                }

                package.Save();

            }
            return fileName;
        }
    }
}
