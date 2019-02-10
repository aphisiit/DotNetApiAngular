using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
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
        string ExportMultiItemData(string fileNames);
    }

    public class ItemService : IItemService
    {
        public readonly PsmContext psmContext;
        public readonly DotNetCoreContext dotNetCoreContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public ItemService(IHostingEnvironment hostingEnvironment,ILogger<ItemService> logger)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.psmContext = new PsmContext();
            this.dotNetCoreContext = new DotNetCoreContext();
            this._logger = logger;
        }

        public string ExportItemDataToExcel(string fileNames)
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"" + fileNames + ".xlsx";

            AppParameter appParameter = (from x in this.dotNetCoreContext.AppParameter
                                        where x.Code == "400"
                                        select x).FirstOrDefault();
            ParameterDetail parameterDetail = (from x in this.dotNetCoreContext.ParameterDetail
                                               where x.Code == "417" && x.AppParameter == appParameter.Id
                                               select x).FirstOrDefault();

            
            Console.WriteLine($"appParameter.Code : {appParameter.Code}");
            Console.WriteLine($"parameterDetail.ParameterValue1 : {parameterDetail.ParameterValue1}");

            FileInfo file = new FileInfo(Path.Combine(parameterDetail.ParameterValue1, fileName));

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
            return parameterDetail.ParameterValue1 + fileName;
        }

        public string ExportMultiItemData(string fileNames)
        {            
            string fileName = @"" + fileNames + ".xlsx";

            AppParameter appParameter = (from x in this.dotNetCoreContext.AppParameter
                                         where x.Code == "400"
                                         select x).FirstOrDefault();
            ParameterDetail parameterDetail = (from x in this.dotNetCoreContext.ParameterDetail
                                               where x.Code == "417" && x.AppParameter == appParameter.Id
                                               select x).FirstOrDefault();


            Console.WriteLine($"appParameter.Code : {appParameter.Code}");
            Console.WriteLine($"parameterDetail.ParameterValue1 : {parameterDetail.ParameterValue1}");

            FileInfo file = new FileInfo(Path.Combine(parameterDetail.ParameterValue1, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {

                var multiItem = from item in this.psmContext.Item
                                join productType in this.psmContext.ProductType on item.ProductType equals productType.Id
                                join productSubType in this.psmContext.ProductSubType on item.ProductSubType equals productSubType.Id
                                join boardCombination in this.psmContext.BoardCombination on item.BoardCombination equals boardCombination.Id
                                join corrugaingProcess in this.psmContext.CorrugatingProcess on item.CorrugatingProcess equals corrugaingProcess.Id
                                join printingTechnology in this.psmContext.PrintingTechnology on item.PrintingTechnology equals printingTechnology.Id
                                join flute in this.psmContext.Flute on item.Flute equals flute.Id
                                select new
                                {
                                    FullSellText = item.FullSaleText,
                                    SellingBahtTon = item.Sellingbt,
                                    SellingBahtPrice = item.Sellingbpcs,
                                    ContBahtTon = item.Contbt,
                                    ContBahtPrice = item.Contbpcs,
                                    IdLength = item.IdLength,
                                    IdWidth = item.IdWidth,
                                    IdHeight = item.IdHeight,
                                    FgLength = item.FgSheetLength,
                                    FgWidth = item.FgSheetWidth,
                                    ProductionTypeDescription = productType.Description,
                                    ProductSubTypeDescription = productSubType.Description,
                                    BoardCombinationCode = boardCombination.Code,
                                    CorrugaingProcessCode = corrugaingProcess.Code,
                                    PrintingTechnologyDescription = printingTechnology.Description,
                                    FluteCode = flute.Code,
                                    AreaFG = item.Areafg,
                                    WeightPerUnit = item.WeightPerUnit,
                                    CostBahtPrice = item.Costbpcs,
                                    MultiLpMarkUp = item.MultiLpMarkUp
                                };

                //this._logger.LogInformation("This logger view display multuItem value");                

                //foreach (var x in multiItem)
                //{
                //    this._logger.LogInformation($"{x.FullSellText}");
                //}

                ExcelWorksheet worksheet;

                bool found = false;
                foreach (ExcelWorksheet worksheetTemp in package.Workbook.Worksheets)
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

                int totalRows = multiItem.Count();
                this._logger.LogInformation($"totalRows : {totalRows}");

                worksheet.Cells[1, 1].Value = "No";
                worksheet.Cells[1, 2].Value = "ContBahtTon";
                worksheet.Cells[1, 3].Value = "ContBahtPrice";
                worksheet.Cells[1, 4].Value = "SellingBahtTon";
                worksheet.Cells[1, 5].Value = "SellingBahtPrice";
                worksheet.Cells[1, 6].Value = "Full saleText";
                worksheet.Cells[1, 7].Value = "ID L";
                worksheet.Cells[1, 8].Value = "ID w";
                worksheet.Cells[1, 9].Value = "ID H";
                worksheet.Cells[1, 10].Value = "FG L";
                worksheet.Cells[1, 11].Value = "FG w";
                worksheet.Cells[1, 12].Value = "Product Type";
                worksheet.Cells[1, 13].Value = "Product SubType";
                worksheet.Cells[1, 14].Value = "Flute";
                worksheet.Cells[1, 15].Value = "BaordCombination";
                worksheet.Cells[1, 16].Value = "Green Carton";
                worksheet.Cells[1, 17].Value = "Print Technology";
                worksheet.Cells[1, 18].Value = "Area FG";
                worksheet.Cells[1, 19].Value = "WeightPerUnit";
                worksheet.Cells[1, 20].Value = "CostBahtPrice";
                worksheet.Cells[1, 21].Value = "% ";
                int i = 0;
                int row = 2;
                //for (int row = 2; row <= totalRows + 1; row++)

                this._logger.LogInformation("Start generate file excel");
                foreach (var x in multiItem)
                {
                    worksheet.Cells[row, 1].Value = i + 1;
                    worksheet.Cells[row, 2].Value = x.ContBahtTon;
                    worksheet.Cells[row, 3].Value = x.ContBahtPrice;
                    worksheet.Cells[row, 4].Value = x.SellingBahtTon;
                    worksheet.Cells[row, 5].Value = x.SellingBahtPrice;
                    worksheet.Cells[row, 6].Value = x.FullSellText;
                    worksheet.Cells[row, 7].Value = x.IdLength;
                    worksheet.Cells[row, 8].Value = x.IdWidth;
                    worksheet.Cells[row, 9].Value = x.IdHeight;
                    worksheet.Cells[row, 10].Value = x.FgLength;
                    worksheet.Cells[row, 11].Value = x.FgWidth;
                    worksheet.Cells[row, 12].Value = x.ProductionTypeDescription;
                    worksheet.Cells[row, 13].Value = x.ProductSubTypeDescription;
                    worksheet.Cells[row, 14].Value = x.FluteCode;
                    worksheet.Cells[row, 15].Value = x.BoardCombinationCode;
                    worksheet.Cells[row, 16].Value = x.CorrugaingProcessCode;
                    worksheet.Cells[row, 17].Value = x.PrintingTechnologyDescription;
                    worksheet.Cells[row, 18].Value = x.AreaFG;
                    worksheet.Cells[row, 19].Value = x.WeightPerUnit;
                    worksheet.Cells[row, 20].Value = x.CostBahtPrice;
                    worksheet.Cells[row, 21].Value = x.MultiLpMarkUp;
                    i++;
                    row++;
                }

                package.Save();
                this._logger.LogInformation("Success generate file excel");
            }
            return parameterDetail.ParameterValue1 + fileName;
        }
    }
}
