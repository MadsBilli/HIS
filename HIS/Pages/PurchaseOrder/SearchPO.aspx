<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchPO.aspx.cs" Inherits="HIS.Pages.PurchaseOrder.SearchPO" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%; width: 98%; padding: 1% 1% 1% 1%; text-align: left;">
        <div>
            <h2 style="color: #46a5dd">
                Purchase Order</h2>
        </div>
        <br />
        <div>
            <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
        </div>
        <br />
        <div>
            <fieldset style="padding: 10px 10px 10px 10px">
                <legend style="font-weight: bold">PO Search</legend>
                <table>
                    <tr>
                        <td colspan="3">
                            PO Date
                        </td>
                        <td>
                            Created By
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dtc1:DateSelectControl ID="DateFrom" runat="server" />
                        </td>
                        <td>
                            To
                        </td>
                        <td>
                            <dtc1:DateSelectControl ID="DateTo" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList Width="140px" ID="CreatedBy" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Supplier Name
                        </td>
                        <td>
                        </td>
                        <td>
                            WO Ref
                        </td>
                        <td>
                            Quote Ref
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWORef" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQuoteRef" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="Panel1" runat="server" GroupingText="PO Status">
                                <asp:RadioButtonList ID="quoteStatus" runat="server" RepeatDirection="Horizontal"
                                    CellSpacing="10">
                                    <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Printed" Value="150"></asp:ListItem>
                                    <asp:ListItem Text="All" Value="-1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                CssClass="button_blue" />&nbsp;
                            <asp:Button ID="btnAddNewPO" Text="New PO" runat="server" OnClick="btnAddNewPO_Click"
                                CssClass="button_blue" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <br />
        <div  id="divResults" runat="server" style="display: none;">
            <fieldset style="height: 330px; padding: 10px 10px 10px 10px">
                <legend style="font-weight: bold">Results</legend>
                <div style="height: 320px; overflow: auto;">
                    <asp:GridView runat="server" ID="gvPO" Width="100%" AutoGenerateColumns="false" AllowPaging="false"
                        CssClass="InsertUpdateDeleteGrid">
                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField HeaderText="PO ID" DataField="po_id" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustName" />
                            <asp:BoundField HeaderText="Date" DataField="po_date" />
                            <asp:BoundField HeaderText="WO Ref" DataField="wo_id" />
                            <asp:BoundField HeaderText="Quote Ref" DataField="quote_id" />
                            <asp:BoundField HeaderText="PO Status" DataField="po_statusdesc" />
                            <asp:BoundField HeaderText="PO By" DataField="po_by" />
                        </Columns>
                        <EmptyDataTemplate>
                            <tr class="InsertUpdateDeleteGridheader" style="width: 807px;">
                                <th scope="col">
                                    PO ID
                                </th>
                                <th scope="col">
                                    Customer Name
                                </th>
                                <th scope="col">
                                    Date
                                </th>
                                <th scope="col">
                                    WO Ref
                                </th>
                                <th scope="col">
                                    Quote Ref
                                </th>
                                <th scope="col">
                                    PO Status
                                </th>
                                <th scope="col">
                                    PO By
                                </th>
                            </tr>
                        </EmptyDataTemplate>
                        <PagerTemplate>
                            <uc:GridViewPager ID="gvPager" runat="server" OnGridViewPageIndexChanged="gvPageIndexChangedEventHandler" />
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
