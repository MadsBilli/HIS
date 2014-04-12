<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankAcctUpdate.ascx.cs" Inherits="HIS.Pages.Setup.UserControls.BankAcctUpdate" %>
<table style="width: 60%;">
    <tr>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
        </td>
        <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
            <table>
                <tr>
                    <td class="legend">
                        <%--<img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')" />
                        <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" style="display: none" />--%>
                        Bank Accounts Update Module
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
            <fieldset>
                <legend>Bank Info</legend>
                <br />
                <table style="margin-left: 20px; width: 100%;">
                    <tr>
                        <td style="width: 100px">Bank Name
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtBankName" runat="server" Width="420px"></asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">Address
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAddress1" runat="server" Width="420px"></asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px"></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAddress2" runat="server" Width="420px"></asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px"></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAddress3" runat="server" Width="420px"></asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">SGD Account</td>
                        <td style="width: 170px">
                            <asp:TextBox ID="txtSGDAcct" runat="server" Width="150px"></asp:TextBox><br />
                            <br />
                        </td>
                        <td style="width: 100px">USD Account</td>
                        <td>
                            <asp:TextBox ID="txtUSDAcct" runat="server" Width="150px"></asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="chkShowIvoice" runat="server" Text="Show Bank Detail in Invoice" />
                        </td>
                    </tr>
                </table>
            </fieldset>
             <div>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                        </td>
                    </tr>
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
