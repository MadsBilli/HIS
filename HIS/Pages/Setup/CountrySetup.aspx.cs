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
    public partial class CountrySetup : System.Web.UI.Page
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
            var res = new CountrySetupAssembler().GetCountrySetupList();            
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
        public static string SaveDetails(CountrySetupUIMapper[] uiMapperDetails)
        {
            foreach (var uiMapper in uiMapperDetails)
            {
                if (string.IsNullOrEmpty(uiMapper.city_code)) continue;
                new CountrySetupAssembler().InsertorUpdateCountrySetupDetails(uiMapper);
            }
            return "true";
        }
    }
}