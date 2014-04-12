<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="HIS.Pages.FabricCode.Preview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="padding: 20px; color: black;">
    <asp:Panel ID="pnlPreview" runat="server">
        <asp:Literal ID="ltlCmpDetails" runat="server"></asp:Literal>
    </asp:Panel>
    <br />
    <u style="font-size: 15px">
        <asp:Literal ID="ltlHeading" runat="server"></asp:Literal></u><br />
    <br />
    <asp:TextBox ID="ltlHeader" runat="server" Rows="6" Columns="100" TextMode="MultiLine"
        CssClass="staticTextArea" Enabled="false"></asp:TextBox>
    <asp:Panel ID="pnlMain" runat="server" Width="100%">
        <asp:Literal runat="server" ID="ltlMain"> 
        </asp:Literal>
    </asp:Panel>
    <asp:Panel ID="pnlFooter" runat="server">
    </asp:Panel>
    </form>
</body>
</html>
