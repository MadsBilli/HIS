<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActiveFinanceMonth.ascx.cs" Inherits="HIS.Pages.Setup.UserControls.ActiveFinanceMonth" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<table style="width: 60%;">
    <tr>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
        </td>
        <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
            <table>
                <tr>
                    <td class="legend">Active Finance Month -
                        <asp:Literal ID="ltlYear" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
        </td>
    </tr>
    <tr>
        <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
        <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif); padding: 20px">
             <div>
                <table style="padding-left: 10px; width: 99%">
                    <tr>
                        <td>
                            <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                        </td>
                    </tr>
                </table>
            </div><br />
            <table style="margin-left: 20px; width: 100%;">
                <tr>
                    <td style="width: 130px">Active Finance Mth:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="50px">
                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>&nbsp;
                         <asp:Button ID="btnSave" runat="server" Text="Save" />
                    </td>
                </tr>
            </table>

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
