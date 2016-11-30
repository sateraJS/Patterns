namespace Xrm.ReportUtility.Models
{
    public class ReportConfig
    {
        public bool WithData { get; set; }

        public bool WithIndex { get; set; }
        public bool WithTotalVolume { get; set; }
        public bool WithTotalWeight { get; set; }

        public bool VolumeSum { get; set; }
        public bool WeightSum { get; set; }
        public bool CostSum { get; set; }
        public bool CountSum { get; set; }
        //возможность убрать из отчёта столбцы «Объём упаковки», «Масса упаковки», «Стоимость», «Количество»
        public bool WithoutPackingVolume { get; set; }
        public bool WithoutPackingWeight { get; set; }
        public bool WithoutCost { get; set; }
        public bool WithoutCount { get; set; }
    }
}
