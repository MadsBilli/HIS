<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewOthers.aspx.cs"
    Inherits="HIS.Pages.FabricCode.PreviewOthers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="padding: 20px; color: black; height: 100%">
    <div style="height: 100%">
        <asp:Panel ID="pnlPreview" runat="server" Style="height: 10%">
            <asp:Literal ID="ltlCmpDetails" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="pnlMain" runat="server" Width="100%" Style="height: 80%">
            <br />
            <u style="font-size: 15px">
                <asp:Literal ID="ltlHeading" runat="server"></asp:Literal></u><br />
            <br />
            <asp:Literal runat="server" ID="ltlMain"> 
            </asp:Literal>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlFooter" runat="server" Style="vertical-align: bottom; height: 10%">
            <asp:TextBox ID="txtFooter" runat="server" Rows="6" Columns="100" TextMode="MultiLine"
                CssClass="staticTextArea" Enabled="false"></asp:TextBox>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
