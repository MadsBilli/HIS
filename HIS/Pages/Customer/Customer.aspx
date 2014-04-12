<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Customer.aspx.cs" Inherits="HIS.Pages.Customer.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DataGrid ID="dgCustomer" runat="server">
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
