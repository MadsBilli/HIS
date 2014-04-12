<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HIS._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="MainContent">
     
     <div id="sliderFrame">
        <div id="slider">
            <img src='<%= ResolveClientUrl("~/Images/img1.jpg") %>' />
            <img src='<%= ResolveClientUrl("~/Images/img2.jpg") %>'   />
            <img src='<%= ResolveClientUrl("~/Images/sample/sam111.jpg") %>'  />
            <img src='<%= ResolveClientUrl("~/Images/sample/sam1111.jpg") %>'  /> 
        </div> 
    </div>
</asp:Content>

