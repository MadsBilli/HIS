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
    public partial class MenuStrip : System.Web.UI.UserControl
    {
        MenuSession menuSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            mainRow.Style.Add("width", "100%");
            if (vsModule != null)
            {
                menuSession = new MenuSession(Session);
                CreateMenu(vsModule);
                return;
            }

            if (!IsPostBack)
            {
                menuSession = new MenuSession(Session);
                List<Module> lstModules = (List<Module>)Module.GetCGHModules();
                if (lstModules != null && lstModules.Count > 0)
                {
                    CreateMenu(lstModules);
                    vsModule = lstModules;
                }
            }
        }

        private List<Module> vsModule
        {
            get { return this.ViewState["vsModule"] != null ? (ViewState["vsModule"] as List<Module>) : null; }
            set { this.ViewState["vsModule"] = value; }
        }

        private void CreateMenu(List<Module> lstModules)
        {
            // mainRow.Height = Unit.Pixel(25);
            mainRow.VerticalAlign = VerticalAlign.Middle;

            TableCell tdMenu;
            Int16 iCount = 1;
            foreach (Module lstModuleItems in lstModules)
            {
                tdMenu = new TableCell();
                tdMenu.Height = Unit.Pixel(15);
                tdMenu.VerticalAlign = VerticalAlign.Middle;

                int intWidth = 70;
                tdMenu.Width = lstModuleItems.ModuleName.ToLower().Contains(" ") ? Unit.Pixel(170) : Unit.Pixel(intWidth);

                tdMenu.CssClass = "mainmenu";

                string strModule = lstModuleItems.ModuleName;

                tdMenu.Text = strModule;
                tdMenu.Attributes.Add("onmouseover", "on_mousehover(this);");
                tdMenu.Attributes.Add("onmouseout", "on_mouseout(this);");

                if (menuSession != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(menuSession.MenuSelected)))
                    {
                        if (menuSession.MenuSelected.ToString() == lstModuleItems.ModuleId.GetHashCode().ToString())
                            tdMenu.CssClass = "mainmenuHighlight";
                    }
                }
                else
                {
                    if (lstModuleItems.ModuleId == 0)
                        tdMenu.CssClass = "mainmenuHighlight";
                }

                tdMenu.Attributes.Add("onclick", "javascript:window.location.href='" + ResolveClientUrl(lstModuleItems.URL) + "'");
                mainRow.Cells.Add(tdMenu);

                //if (lstModuleItems.ModuleId != 10)
                //{
                //    TableCell tdSplit = new TableCell();
                //    //tdSplit.Height = Unit.Pixel(25);
                //    //tdSplit.VerticalAlign = VerticalAlign.Middle;
                //    tdSplit.Width = Unit.Pixel(1);
                //    //tdSplit.Style.Add(HtmlTextWriterStyle.PaddingLeft, "0px");
                //    tdSplit.CssClass = "mainmenu";
                //    if (lstModules.Count != iCount)
                //        tdSplit.Text = "|";
                //    mainRow.Cells.Add(tdSplit);
                //}

                if (lstModules.Count != iCount)
                {
                    TableCell tdSplit = new TableCell();
                    tdSplit.Width = Unit.Pixel(1);
                    tdSplit.CssClass = "mainmenu";
                    tdSplit.Text = "|";
                    mainRow.Cells.Add(tdSplit);
                }
                iCount++;
            }

            tdMenu = new TableCell();
            tdMenu.Height = Unit.Pixel(15);
            tdMenu.VerticalAlign = VerticalAlign.Middle;
            tdMenu.CssClass = "mainmenu";
            tdMenu.Text = string.Empty;
            mainRow.Cells.Add(tdMenu);
        }
    }
}