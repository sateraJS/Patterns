using System.IO;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private readonly string[] _args;

        protected ReportServiceBase(string[] args)
        {
            _args = args;
        }
        /* Шаблонный метод GetDataRows. ReportServiceBase - абстрактный класс; CsvReportService, XlsxReportService, TxtReportService - подклассы, переопределяющие значение GetDataRows*/
        public Report CreateReport()
        {
            var config = ParseConfig();
            /*DataTransformerCreator - фабричный метод для создания цепочки обязанностей, тк мы изначально не знаем какие методы нам понадобятся*/
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = _args[0];
            var text = File.ReadAllText(fileName);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        private ReportConfig ParseConfig()
        {
            return new ReportConfig
            {
                WithData = _args.Contains("-data"),

                WithIndex = _args.Contains("-withIndex"),
                WithTotalVolume = _args.Contains("-withTotalVolume"),
                WithTotalWeight = _args.Contains("-withTotalWeight"),

                VolumeSum = _args.Contains("-volumeSum"),
                WeightSum = _args.Contains("-weightSum"),
                CostSum = _args.Contains("-costSum"),
                CountSum = _args.Contains("-countSum"),
                //возможность убрать из отчёта столбцы «Объём упаковки», «Масса упаковки», «Стоимость», «Количество»
                WithoutPackingVolume = _args.Contains("-withoutPackingVolume"),
                WithoutPackingWeight = _args.Contains("-withoutPackingWeight"),
                WithoutCost = _args.Contains("-withoutCost"),
                WithoutCount = _args.Contains("-withoutCount")
            };
        }

        protected abstract DataRow[] GetDataRows(string text);
    }
}
