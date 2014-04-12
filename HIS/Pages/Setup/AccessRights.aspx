<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessRights.aspx.cs" Inherits="HIS.Pages.Setup.AccessRights" %>
<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="padding-left: 10px; width: 99%">
            <tr>
                <td>
                    <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                </td>
            </tr>
        </table>
        </div>
     <div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">
                                Access Right Control
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
                </td>
            </tr>

            <tr id="trMainMid">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="main">
                        <table>
                            <tr>
                                <td>
                                    Access Right Type
                                </td>
                                <td><asp:DropDownList ID="ddlAccessRightType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAccessRightType_SelectedIndexChanged"></asp:DropDownList> </td>
                            </tr>
                        </table>
                        <table><tr><td class="verticalSpace"></td></tr></table>
                        <table>
                            <tr>
                                <td>UPC Code</td>
                                <td><asp:CheckBox id="chkUPCCode" runat="server"/> </td>
                                <td style="width:50px"></td>
                                <td>Vendor</td>
                                <td><asp:CheckBox id="chkVendor" runat="server"/> </td>
                                <td style="width:50px"></td>
                                <td>Aging</td>
                                <td><asp:CheckBox id="chkAging" runat="server"/> </td>
                            </tr> 
                            <tr><td class="verticalSpace"></td></tr>
                            <tr>
                                <td>Inventory</td>
                                <td><asp:CheckBox id="chkInventory" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Purchase Invoice</td>
                                <td><asp:CheckBox id="chkPurchaseInvoice" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Reports</td>
                                <td><asp:CheckBox id="chkReports" runat="server"/> </td>
                            </tr>
                             <tr><td class="verticalSpace"></td></tr>
                            <tr>
                                <td>System Setup</td>
                                <td><asp:CheckBox id="chkSystemSetup" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Payments</td>
                                <td><asp:CheckBox id="chkPayments" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Emp Admin</td>
                                <td><asp:CheckBox id="chkEmpAdmin" runat="server"/> </td>
                            </tr>
                             <tr><td class="verticalSpace"></td></tr>
                             <tr>
                                <td>Finance AccCode</td>
                                <td><asp:CheckBox id="chkFinanceAccCode" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Customer</td>
                                <td><asp:CheckBox id="chkCustomer" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Sales Commission</td>
                                <td><asp:CheckBox id="chkSalesCommission" runat="server"/> </td>
                            </tr>
                             <tr><td class="verticalSpace"></td></tr>
                             <tr>
                                <td>Finance General-GL</td>
                                <td><asp:CheckBox id="chkFinanceGeneral" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Invoice</td>
                                <td><asp:CheckBox id="chkInvoice" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Work Order</td>
                                <td><asp:CheckBox id="chkWorkOrder" runat="server"/> </td>
                            </tr>
                             <tr><td class="verticalSpace"></td></tr>
                             <tr>
                                <td>Finance PO</td>
                                <td><asp:CheckBox id="chkFinancePO" runat="server"/> </td>
                                <td style="width:10px"></td>
                                <td>Receipts</td>
                                <td><asp:CheckBox id="chkReceipts" runat="server"/> </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif); background-repeat: no-repeat"></td>
            </tr>
            <tr id="trMainBtm">
                <td style="width: 1%">
                    <img src="../../Images/table_btm_left.gif" />
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_btm_mid.gif)"></td>
                <td style="width: 1%">
                    <img src="../../Images/table_btm_right.gif" />
                </td>
            </tr>
        </table>

         <table>
             <tr>
                 <td><asp:Button id="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/><asp:Button id="btnCancel" runat="server" Text="Cancel"/> </td>
             </tr>
         </table>
    </div>
</asp:Content>
