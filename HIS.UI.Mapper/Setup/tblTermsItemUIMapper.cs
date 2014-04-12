using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Common;

namespace HIS.UI.Mapper.Setup
{
    public class tblTermsItemUIMapper
    {
        public int int_ID { get; set; }
        public int intTermID { get; set; }
        public string txtLN { get; set; }
        public string txtDescription { get; set; }
        public Operation operation { get; set; }
    }
}
