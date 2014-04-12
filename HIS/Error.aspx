<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HIS.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <p class="pageSubTitle"> An error has occurred in the Application. </p>

    <br />
    <br />
    <p>Error:</p>
    <asp:Literal ID="litErrorMsg" runat="server"></asp:Literal>
    <br />
    <p>Detailed Error:</p>
    <asp:Literal ID="litStacktrace" runat="server"></asp:Literal>
</asp:Content>
