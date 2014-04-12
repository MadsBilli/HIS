<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateControl.ascx.cs" Inherits="HIS.UserControl.DateControl" %>
<table  border="0">
    <tr>
        <td style="height: 24px">
            <asp:TextBox ID="txtDate" runat="server" Width="80"/><a href="javascript:void(0);"
                style="border: none;">
                <asp:Image ID="imgCalender" runat="server" ImageUrl="~/Images/calendar.jpeg"
                    AlternateText="Calendar" CssClass="calender" />
            </a>
        </td>
    </tr>
</table>