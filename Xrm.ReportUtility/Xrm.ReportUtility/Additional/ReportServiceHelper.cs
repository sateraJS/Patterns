
using System;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Additional
{
    /* фабричный метод */
    public static class ReportServiceHelper
    {
        public static IReportService Create(string[] args)
        {
            if (args[0].EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (args[0].EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (args[0].EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }
            throw new NotSupportedException("this extension not supported");
        }
    }
}
