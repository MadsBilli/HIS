<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridViewPager.ascx.cs" Inherits="HIS.UserControl.GridViewPager"%>
<table style="height:25px; width:100%;"  >
    <tr>
        <td style="width:200px">
            <div style="float:left;">
                <asp:Label ID="lblGotoPage" runat="server" />
                <asp:TextBox ID="txtPageNo" runat="server" Width="30px" Height="15px" onkeypress="return IsNumberKey(event);" onpaste="return ValidateGridViewPagerControl(this, event);" onblur="return ValidateGridViewPagerControl(this, event);" />
               <asp:Label ID="lblPageNo" runat="server" />
            </div>
            <%--<div style="float:left; padding-left:3px; padding-top:2px;">
                <asp:Button ID="btnGo" runat="server" Text="Go"  
                    OnClick="GoButtonClickEventHandler" Width="35" Height="15" 
                    CausesValidation="False" />
            </div>--%>
        </td>
        <td>
            <table style="width:100%">
                <tr>
                    <td style="width:25%" ><asp:LinkButton ID="lbFirst" Text="First <<"  CommandArgument="First" runat="server" OnClick="PageChangeButtonClickEventHandler" /></td>
                    <td style="width:25%"><asp:LinkButton ID="lbPrevious" Text="Prev <" CommandArgument="Prev" runat="server" OnClick="PageChangeButtonClickEventHandler" /></td>
                    <td style="width:25%"><asp:LinkButton ID="lbNext" Text="Next >" CommandArgument="Next" runat="server" OnClick="PageChangeButtonClickEventHandler" /></td>
                    <td style="width:25%"><asp:LinkButton ID="lbLast" Text="Last >>" CommandArgument="Last" runat="server" OnClick="PageChangeButtonClickEventHandler" /></td>   
                </tr>
            </table>
        </td>
    </tr>
</table>
