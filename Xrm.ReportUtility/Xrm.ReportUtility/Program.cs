using System;
using System.Linq;
using Xrm.ReportUtility.Additional;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        //"Files/table.txt" -data -weightSum -costSum -withIndex -withTotalWeight -withoutPackingWeight
        public static void Main(string[] args)
        {
            //var service = GetReportService(args); 
            var service = ReportServiceHelper.Create(args); // Вынесено в фабричный метод

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
        /* Вынесем в отдельный фабричный метод - ReportServiceHelper
        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }
        */

        private static void PrintReport(Report report)
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                /* для упрощения создания headerRow и rowTemplate можно создать Строитель для них */
                /*var headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество";
                var rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";

                if (report.Config.WithIndex)
                {
                    headerRow = "№\t" + headerRow;
                    rowTemplate = "{0}\t" + rowTemplate;
                }
                if (report.Config.WithTotalVolume)
                {
                    headerRow = headerRow + "\tСуммарный объём";
                    rowTemplate = rowTemplate + "\t{6,15}";
                }
                if (report.Config.WithTotalWeight)
                {
                    headerRow = headerRow + "\tСуммарный вес";
                    rowTemplate = rowTemplate + "\t{7,13}";
                }
                
                 Console.WriteLine(headerRow);
                 for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }
                 */
                var rowBuilder = new StringBuilder();
                //rowBuilder.AddEnd("Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество", 
                //    "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}");
                if(!report.Config.WithoutPackingVolume)
                    rowBuilder.PackingVolume();
                if (!report.Config.WithoutPackingWeight)
                    rowBuilder.PackingWeight();
                if (!report.Config.WithoutCost)
                    rowBuilder.Cost();
                if (!report.Config.WithoutCount)
                    rowBuilder.Count();

                if (report.Config.WithIndex)
                {
                    // rowBuilder.AddTop("№\t", "{0}\t");
                    rowBuilder.Index();
                }
                if (report.Config.WithTotalVolume)
                {
                    // rowBuilder.AddEnd("\tСуммарный объём", "\t{6,15}");
                    rowBuilder.TotalVolume();
                }
                if (report.Config.WithTotalWeight)
                {
                    // rowBuilder.AddEnd("\tСуммарный вес", "\t{7,13}");
                    rowBuilder.TotalWeight();
                }
                Console.WriteLine(rowBuilder.Result.HeaderRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowBuilder.Result.RowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine(string.Format("  {0,-20}\t{1}", reportRow.Name, reportRow.Value));
                }
            }
        }
    }
}