using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class RptPrintingSetupUIMapper
    {
        public string rt_name { get; set; }
        public string rt_display_name { get; set; }
        public bool rt_allow_edit { get; set; }
        public string rt_form { get; set; }
        public string rt_table { get; set; }
        public string rt_id { get; set; }
        public string rt_criteria { get; set; }
        public string primaryKey { get; set; }
    }
}
