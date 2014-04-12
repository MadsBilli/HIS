using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Common;


namespace HIS.UI.Mapper.Setup
{
    public class tblTermsUIMapper
    {
        public int int_ID { get; set; }
        public string txtDescription { get; set; }
        public string txtType { get; set; }
        public string txtSelect { get; set; }
        public Operation operation { get; set; }

    }
}
