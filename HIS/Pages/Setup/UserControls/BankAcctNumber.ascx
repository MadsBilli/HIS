<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankAcctNumber.ascx.cs" Inherits="HIS.Pages.Setup.UserControls.BankAcctNumber" %>
<asp:RadioButtonList ID="rdbAcctNum" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Text="SGD Account" Value="10" />
    <asp:ListItem Text="USD Account" Value="20" />
</asp:RadioButtonList>
<br />
<div id="sgdDiv" class="hide">
    <table>
        <tr>
            <td>SGD Bank Acc No.</td>
        </tr>
        <tr>
            <td>
                <input id="txtSGDNum" type="text" />&nbsp;<input id="btnSGDUpdate" type="button" value="Update" onclick="UpdateSGDAcct();"/>
            </td>
        </tr>
    </table>
</div>
<div id="usdDiv"  class="hide">
    <table>
        <tr>
            <td>USD Bank Acc No.</td>
        </tr>
        <tr>
            <td>
                <input id="txtUSDNum" type="text" />&nbsp;<input id="btnUSDUpdate" type="button" value="Update" onclick="UpdateUSDAcct();"/>
            </td>
        </tr>
    </table>
</div>
