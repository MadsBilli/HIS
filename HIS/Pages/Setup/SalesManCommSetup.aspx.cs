using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.Setup
{
    public partial class SalesManCommSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDataGrid();
            }
        }

        private void BindDataGrid()
        {
            var res = new SalesManCommSetupAssembler().GetSalesManCommSetupList();           
            gvList.DataSource = res;
            gvList.DataBind();
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        public string ProcessData(object value)
        {
            return Convert.ToInt32(value) == 0 ? "" : value.ToString();
        }

        [WebMethod]
        public static string SaveDetails(SalesManCommSetupUIMapper[] uiMapperDetails)
        {
            foreach (var uiMapper in uiMapperDetails)
            {
                if (string.IsNullOrEmpty(uiMapper.emp_salesman_com))
                {
                    uiMapper.emp_salesman_com = "0.02";
                }
                else
                    uiMapper.emp_salesman_com = ((double.Parse(uiMapper.emp_salesman_com.Replace("%", "")))/100.00).ToString();
                new SalesManCommSetupAssembler().UpdateSalesManCommSetupDetails(uiMapper);
            }
            return "true";
        }
    }
}