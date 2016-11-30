using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.ReportUtility.Additional
{
    public class StringBuilder
    {
        private string _header;
        private string _template;
       /* public StringBuilder()
        {
            _header = string.Empty;
            _template = string.Empty;
        }*/
        public StringBuilder()
        {
            _header = "Наименование";
            _template = "{1,12}";
        }
        public StringBuilder AddEnd(string header, string template)
        {
            _header = _header + header;
            _template = _template + template;
            return this;
        }
        public StringBuilder AddTop(string header, string template)
        {
            _header = header + _header;
            _template = template + _template;
            return this;
        }
        public StringBuilder PackingVolume()
        {
            return AddEnd("\tОбъём упаковки", "\t{2,14}");
        }
        public StringBuilder PackingWeight()
        {
            return AddEnd("\tМасса упаковки", "\t{3,14}");
        }
        public StringBuilder Cost()
        {
            return AddEnd("\tСтоимость", "\t{4,9}");
        }
        public StringBuilder Count()
        {
            return AddEnd("\tКоличество", "\t{5,10}");
        }
        public StringBuilder Index()
        {
            return AddTop("№\t", "{0}\t");
        }
        public StringBuilder TotalVolume()
        {
            return AddEnd("\tСуммарный объём", "\t{6,15}");
        }
        public StringBuilder TotalWeight()
        {
            return AddEnd("\tСуммарный вес", "\t{7,13}");
        }
        public Template Result => new Template { HeaderRow = _header, RowTemplate = _template };
    }
    public class Template
    {
        public string HeaderRow { get; set; }
        public string RowTemplate { get; set; }
    }
}
