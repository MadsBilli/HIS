<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetupLandingPage.aspx.cs" Inherits="HIS.Pages.Setup.SetupLandingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td style="height: 25px"></td>
            </tr>
        </table>
    </div>
    <div style="width:100%">
        <table style="width:100%" class="pageSubTitle">                      
            <tr>
                <td class="pageSubTitle">
                    <a href="../Employee/EmployeeAdminAddEdit.aspx">User Administration</a>
                </td>
                <td><a href="SystemSettingSetup.aspx">System Setting</a></td>
                <td class="pageSubTitle">
                    <a href="BUNameSetup.aspx">BU Name Setup</a>
                </td>
                <td class="pageSubTitle">
                    <a href="UseLogListing.aspx">User Login Log</a>
                </td>
            </tr>
            <tr>
                <td><a href="CurrencySetup.aspx">Currency Setup</a></td>
                <td><a href="FinanceSettingSetup.aspx">Finance Setting Setup</a></td>
                <td class="pageSubTitle">
                    <a href="CountrySetup.aspx">Country Administration</a>
                </td>
                <td class="pageSubTitle">
                    <a href="InvoiceItemsSelectionSetup.aspx">Inv Selection List</a>
                </td>
            </tr>
            <tr>
                <td><a href="javascript:void(0);">Terms Setup</a></td>
                <td><a href="AccessRights.aspx">Access Right Ctrl</a></td>
                <td class="pageSubTitle">
                    <a href="UOMSetup.aspx">UOM Setup</a>
                </td>
                <td class="pageSubTitle">
                    <a href="RptPrintingSetup.aspx">Rpt Printing Setup</a>
                </td>
            </tr>
            <tr>
                <td class="pageSubTitle">
                    <a href="SalesManCommSetup.aspx">Salesman Commission</a>
                </td>
                <td class="pageSubTitle">
                    <a href="../FabricCode/FabricCodeAddEdit.aspx">Fabric Code Setup</a>
                </td>
                <td></td>
                <td></td>
            </tr>            
        </table>
    </div>
</asp:Content>
