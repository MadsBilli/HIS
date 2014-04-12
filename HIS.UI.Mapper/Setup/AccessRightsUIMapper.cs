using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class AccessRightsUIMapper
    {
        public Int16 emp_sqno { get; set; }
        public int emp_type { get; set; }
        public string emp_typedesc { get; set; }
        public bool fm_upc { get; set; }
        public bool fm_inventory { get; set; }
        public bool fm_pos { get; set; }
        public bool fm_acc { get; set; }
        public bool fm_gen { get; set; }
        public bool fm_po { get; set; }
        public bool fm_ven { get; set; }
        public bool fm_pur_inv { get; set; }
        public bool fm_pay { get; set; }
        public bool fm_cust { get; set; }
        public bool fm_inv { get; set; }
        public bool fm_rec { get; set; }
        public bool fm_aging { get; set; }
        public bool fm_rpt { get; set; }
        public bool fm_payroll { get; set; }
        public bool fm_emp_admin { get; set; }
        public bool fm_setup { get; set; }
        public bool fm_commission { get; set; }
        public bool fm_misc_gl { get; set; }
        public bool fm_wo { get; set; }
    }
}
