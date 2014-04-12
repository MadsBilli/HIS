<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidationMessage.ascx.cs" Inherits="HIS.UserControl.ValidationMessage" %>
<table style=" text-align: left;"
    id="tblMsgInfo" runat="server" visible="false"
    width="100%">
    <tr id="trError" runat="server" visible="false">
        <td style="width: 3%; height: 26px; background-color: #fbc3c1; border: solid 1px #812f2f;
            border-right: none;">
            <img src='<%= ResolveClientUrl("~/Images/unsuccessful.gif") %>' alt="UnSuccess" />
        </td>
        <td style="width:97%; background-color: #fbc3c1; border: solid 1px #812f2f; border-left: none;vertical-align:middle">
            <span >
                <asp:Literal ID="ltrErrorMessage" runat="server" /></span>
        </td>
    </tr>
    <tr id="trSuccess" runat="server" visible="false">
        <td style="width: 3%; height: 26px; background-color: #e6f8de; border: solid 1px #2f813f;
            border-right: none;">
            <%--<img src='<%= ResolveClientUrl("~/Images/successful.gif") %>' alt="Success" />--%>
        </td>
        <td style="width:97%; background-color: #e6f8de; border: solid 1px #2f813f; border-left: none;vertical-align:middle">            
                <asp:Literal ID="ltrSuccessMessage" runat="server" />
        </td>
    </tr>
   
    <tr id="trInfo" runat="server" visible="false">
        <td style="width: 3%; background-color: #fbfbe0; border: solid 1px #817a2f;
            border-right: none;vertical-align:top">
            <img src='<%= ResolveClientUrl("~/Images/info.gif") %>' alt="Error" />
        </td>
        <td style="width:97%; background-color: #fbfbe0; border: solid 1px #817a2f; border-left: none;">
            <span style="padding-left: 10px;">
                <asp:Literal ID="ltrInformation" runat="server" /></span>
        </td>
    </tr>
     <tr id="trErrorList" runat="server" visible="false">
         <td style="width: 3%; background-color: #fbc3c1; border: solid 1px #812f2f; border-right: none; vertical-align:top">
            <img src='<%= ResolveClientUrl("~/Images/unsuccessful.gif") %>' alt="UnSuccess" />
        </td>
        <td style="width:97%; background-color: #fbc3c1; border: solid 1px #812f2f; border-left: none;vertical-align:top">
            <span >
            <asp:Literal ID="ltrErrorList" runat="server" /></span>
        </td>
    </tr>
</table>
