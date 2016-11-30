using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    /*Цепочка обязанностей ReportServiceTransformerBase, где CostSumReportTransformer, CountSumReportTransformer и подобные - конкретные обработчики*/
    public abstract class ReportServiceTransformerBase : IDataTransformer
    {
        protected readonly IDataTransformer DataTransformer;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data);
    }
}
