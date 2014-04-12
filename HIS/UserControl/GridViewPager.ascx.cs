using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using System.Threading;
using System.Web.UI.HtmlControls;
using HIS.UI.SessionManagement;
using HIS.UI.Common;

namespace HIS.UserControl
{
    public partial class GridViewPager : System.Web.UI.UserControl
    {
        public delegate void DelegateGridViewPageIndexChanged(object sender, GridViewPageEventArgs e);
        public event DelegateGridViewPageIndexChanged GridViewPageIndexChanged;

        #region Private Variables
        private string _go_to_page_text_;
        private string _fisrt_page_text_;
        private string _previous_page_text_;
        private string _next_page_text_;
        private string _last_page_text;
        #endregion

        #region Public Properties
        public string LastPageText
        {
            get { return _last_page_text; }
            set { _last_page_text = value; }
        }

        public string NextPageText
        {
            get { return _next_page_text_; }
            set { _next_page_text_ = value; }
        }
        public string PreviousPageText
        {
            get { return _previous_page_text_; }
            set { _previous_page_text_ = value; }
        }
        public string FirstPageText
        {
            get { return _fisrt_page_text_; }
            set { _fisrt_page_text_ = value; }
        }
        public string GotoPageText
        {
            get { return _go_to_page_text_; }
            set { _go_to_page_text_ = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            if (!IsPostBack)
            {
                txtPageNo.Text = string.Empty;
            }
            //Setting the Page Size
            GridView parentGridView = this.GetGridView();
            if (parentGridView != null)
            { parentGridView.PageSize = parentGridView.PageSize == 0 ? HIS.UI.Common.CommonFunctions.GetGridPageSize() : parentGridView.PageSize; }

            SetMinMaxPage();
            SetLabel();
        }

        protected void GoButtonClickEventHandler(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPageNo.Text))
            {
                SetNewPage(Convert.ToInt32(txtPageNo.Text));
            }
        }

        protected void PageChangeButtonClickEventHandler(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            GridView grid = this.GetGridView();
            if (button != null && grid != null)
            {
                switch (button.CommandArgument)
                {
                    case "First":
                        SetNewPage(1);
                        break;
                    case "Prev":
                        SetNewPage(grid.PageIndex);
                        break;
                    case "Next":
                        SetNewPage(grid.PageIndex + 2);
                        break;
                    case "Last":
                        SetNewPage(grid.PageCount);
                        break;
                }
            }
        }

        private void SetNewPage(int pageNo)
        {
            GridView gridview = this.GetGridView();
            if (gridview != null && this.GridViewPageIndexChanged != null)
            {
                if (pageNo > 0 && pageNo <= gridview.PageCount && pageNo - 1 != gridview.PageIndex)
                {
                    GridViewPageEventArgs evt = new GridViewPageEventArgs(pageNo - 1);
                    this.GridViewPageIndexChanged(gridview, evt);
                }
            }
        }

        private GridView GetGridView()
        {
            GridViewRow row = this.NamingContainer as GridViewRow;
            if (row != null)
            {
                return row.NamingContainer as GridView;
            }

            return null;
        }

        private void SetLabel()
        {
            GridView grid = this.GetGridView();
            if (grid != null)
            {
                if (string.IsNullOrEmpty(txtPageNo.Text))
                {
                    txtPageNo.Text = (grid.PageIndex + 1).ToString();
                }

                lblPageNo.Text = string.Format("of {0}", grid.PageCount);
                lbFirst.Enabled = grid.PageIndex > 0;
                lbLast.Enabled = grid.PageIndex < grid.PageCount - 1;
                lbPrevious.Enabled = lbFirst.Enabled;
                lbNext.Enabled = lbLast.Enabled;
            }

            lblGotoPage.Text = string.IsNullOrEmpty(this.GotoPageText) ? "Go to Page:" : this.GotoPageText;
            lbFirst.Text = string.IsNullOrEmpty(this.FirstPageText) ? "First <<" : this.FirstPageText;
            lbPrevious.Text = string.IsNullOrEmpty(this.PreviousPageText) ? "Prev <" : this.PreviousPageText;
            lbNext.Text = string.IsNullOrEmpty(this.NextPageText) ? "Next >" : this.NextPageText;
            lbLast.Text = string.IsNullOrEmpty(this.LastPageText) ? "Last >>" : this.LastPageText;
        }

        private void SetMinMaxPage()
        {
            txtPageNo.MaxLength = 1;
            GridView grid = this.GetGridView();
            int maxVal = 1;
            if (grid != null)
            {
                maxVal = grid.PageCount;
                txtPageNo.MaxLength = (grid.PageCount).ToString().Length;
            }

            txtPageNo.Attributes.Add("MaxValue", maxVal.ToString());
        }
    }
}