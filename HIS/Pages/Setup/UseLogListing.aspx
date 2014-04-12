<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UseLogListing.aspx.cs" Inherits="HIS.Pages.Setup.UseLogListing" %>
<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="padding-left: 10px; width: 99%">

            <tr>
                <td>
                    <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                </td>
            </tr>
            <tr><td style="height:20px"></td></tr>
        </table>
    <asp:GridView runat="server" ID="gvUseLogListing" Width="80%" AutoGenerateColumns="false" AllowPaging="true"
                        OnRowDataBound="gvUseLogListingGridRowDataBoundEneventHandler">
                        <Columns>
                            <asp:BoundField DataField="emp_logname" HeaderText="Log name" />
                            <asp:BoundField DataField="emp_name" HeaderText="User Name" />
                            <asp:BoundField DataField="log_datetime" HeaderText="Start Date/Time"   />
                            <asp:TemplateField HeaderText="Connected Time"    >
                                <ItemTemplate>
                                    <asp:Label ID="lblConnectedTime" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="80">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgTerminateUser" runat="server" ImageUrl="~/Images/DELETE_1.GIF" ToolTip="Terminate User Connection"
                                        CommandArgument='<%# Eval("emp_logname") %>' OnClick="TerminateUser" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <uc:GridViewPager ID="gvPager" runat="server" OnGridViewPageIndexChanged="gvPageIndexChangedEventHandler" />
                        </PagerTemplate>
                        <EmptyDataRowStyle CssClass="hide" />
                    </asp:GridView>
</asp:Content>
