<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceSettingSetup.aspx.cs" Inherits="HIS.Pages.Setup.FinanceSettingSetup" EnableEventValidation="true" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="UserControls/BankAcctUpdate.ascx" TagName="BankAcctUpdate" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Script/SetupCommonScript.js"></script>
    <script src="Script/FinanceSettingSetupScript.js"></script>
    <script src="Script/LinkAccountScript.js"></script>
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
        <table>
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">
                                Financial Setting Setup
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
                </td>
            </tr>
            <tr>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div>
                        <br />
                        Setup Type:
                        <asp:DropDownList ID="ddlSetupType" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Bank Name/Address" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Bank Acc Number" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Financial Month Table" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Links Accounts" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Tax" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Password" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div>
                        <asp:PlaceHolder runat="server" ID="Placeholder1"></asp:PlaceHolder>
                    </div>
                    <div id="divFooter">
                        <table id="tblfooter" style="margin-left: 7px;">
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif); background-repeat: no-repeat"></td>
                <td></td>
            </tr>

            <tr>
                <td style="width: 1%">
                    <img src="../../Images/table_btm_left.gif" />
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_btm_mid.gif)"></td>
                <td style="width: 1%">
                    <img src="../../Images/table_btm_right.gif" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
