<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinanceCtrlPwd.ascx.cs" Inherits="HIS.Pages.Setup.UserControls.FinanceCtrlPwd" %>
<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<table style="width: 30%;">
    <tr>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
        </td>
        <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
            <table>
                <tr>
                    <td class="legend">Change Finance Control Password
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
                    <td style="width: 100px">Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">New Password
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
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

