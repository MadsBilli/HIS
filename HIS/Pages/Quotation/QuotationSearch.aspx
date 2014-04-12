<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QuotationSearch.aspx.cs" Inherits="HIS.Pages.Quotation.QuotationSearch" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
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
    </table>
    <table style="width: 100%;">
        <tr>
            <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif);
                background-repeat: no-repeat">
                &nbsp;
            </td>
            <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                <table>
                    <tr>
                        <td class="legend">
                            <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')"
                                style="display: none" />
                            <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                background-repeat: no-repeat">
                &nbsp;
            </td>
        </tr>
        <tr id="trContMid">
            <td style="vertical-align: bottom; background-image: url('../../Images/table_left_mid.gif');
                background-repeat: no-repeat">
            </td>
            <td style="vertical-align: bottom; background-image: url('../../Images/table_centre_mid.gif')">
                <div id="Contact">
                    <table>
                        <tr>
                            <td colspan="3">
                                Quote Date
                            </td>
                            <td>
                                Quote By
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dtc1:DateSelectControl ID="QuoteDateFrom" runat="server" />
                            </td>
                            <td>
                                To
                            </td>
                            <td>
                                <dtc1:DateSelectControl ID="QuoteDateTo" runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList Width="140px" ID="QuoteBy" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer
                            </td>
                            <td>
                            </td>
                            <td>
                                Project
                            </td>
                            <td>
                                Quote Ref
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProject" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuoteRef" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Designer
                            </td>
                        </tr>
                        <tr style="visibility: hidden">
                            <td>
                                <asp:DropDownList Width="90px" ID="Designer" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Panel runat="server" GroupingText="Quote Status">
                                    <asp:RadioButtonList ID="quoteStatus" runat="server" RepeatDirection="Horizontal"
                                        CellSpacing="10">
                                        <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="No Reply" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="Accept" Value="150"></asp:ListItem>
                                        <asp:ListItem Text="Reject" Value="200"></asp:ListItem>
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
                                Sort this search using
                            </td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="sortOrder" runat="server" RepeatDirection="Horizontal" CellSpacing="10"
                                    AutoPostBack="true" OnSelectedIndexChanged="sortOrder_SelectedIndexChanged">
                                    <asp:ListItem Text="Default Sorting Order" Value="default"></asp:ListItem>
                                    <asp:ListItem Text="Your Own Sorting Order" Value="own"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel ID="OwnSortPnl" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                select the fields to sort this search
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sort By
                                            </td>
                                            <td>
                                                <asp:DropDownList Width="90px" ID="sortby1" runat="server">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Quote Ref" Value="quote_id"></asp:ListItem>
                                                    <asp:ListItem Text="Company Name" Value="CompanyName"></asp:ListItem>
                                                    <asp:ListItem Text="Date" Value="quote_date"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="sortOrder1" runat="server" RepeatDirection="Horizontal"
                                                    CellSpacing="10">
                                                    <asp:ListItem Text="A...Z" Value="asc"></asp:ListItem>
                                                    <asp:ListItem Text="Z...A" Value="desc"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Then By
                                            </td>
                                            <td>
                                                <asp:DropDownList Width="90px" ID="sortby2" runat="server">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Quote Ref" Value="quote_id"></asp:ListItem>
                                                    <asp:ListItem Text="Company Name" Value="CompanyName"></asp:ListItem>
                                                    <asp:ListItem Text="Date" Value="quote_date"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="sortOrder2" runat="server" RepeatDirection="Horizontal"
                                                    CellSpacing="10">
                                                    <asp:ListItem Text="A...Z" Value="asc"></asp:ListItem>
                                                    <asp:ListItem Text="Z...A" Value="desc"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sort By
                                            </td>
                                            <td>
                                                <asp:DropDownList Width="90px" ID="sortby3" runat="server">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Quote Ref" Value="quote_id"></asp:ListItem>
                                                    <asp:ListItem Text="Company Name" Value="CompanyName"></asp:ListItem>
                                                    <asp:ListItem Text="Date" Value="quote_date"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="sortOrder3" runat="server" RepeatDirection="Horizontal"
                                                    CellSpacing="10">
                                                    <asp:ListItem Text="A...Z" Value="asc"></asp:ListItem>
                                                    <asp:ListItem Text="Z...A" Value="desc"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                    CssClass="button_blue" />&nbsp;
                                <asp:Button ID="btnAddNewQuotation" Text="New Quotation" runat="server" OnClick="btnAddNewQuotation_Click"
                                    CssClass="button_blue_Long" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td style="vertical-align: bottom; background-image: url('../../Images/table_right_mid.gif');
                background-repeat: no-repeat">
            </td>
        </tr>
        <tr id="trContBtm">
            <td style="width: 1%">
                <img src="../../Images/table_btm_left.gif" />
            </td>
            <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_btm_mid.gif)">
            </td>
            <td style="width: 1%">
                <img src="../../Images/table_btm_right.gif" />
            </td>
        </tr>
    </table>
    <table style="width: 98%">
        <tr>
            <td>
                <asp:GridView runat="server" ID="gvQuoteItem" Width="100%" AutoGenerateColumns="false"
                    AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                    <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                    <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                    <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField HeaderText="Quote Ref" DataField="quote_id" />
                        <asp:BoundField HeaderText="Company Name" DataField="CustName" />
                        <asp:BoundField HeaderText="Date" DataField="quote_date" />
                        <asp:BoundField HeaderText="Salesman" DataField="quote_by" />
                        <asp:BoundField HeaderText="Salesman2" DataField="quote_by2" />
                        <asp:BoundField HeaderText="Quote Status" DataField="quote_statusdesc" />
                        <asp:BoundField HeaderText="Subject" DataField="quote_subject" />
                    </Columns>
                    <EmptyDataTemplate>
                        <tr class="InsertUpdateDeleteGridheader" style="width: 807px;">
                            <th scope="col">
                                Quote Ref
                            </th>
                            <th scope="col">
                                Company Name
                            </th>
                            <th scope="col">
                                Date
                            </th>
                            <th scope="col">
                                Salesman
                            </th>
                            <th scope="col">
                                Salesman2
                            </th>
                            <th scope="col">
                                Quote Status
                            </th>
                            <th scope="col">
                                Subject
                            </th>
                        </tr>
                    </EmptyDataTemplate>
                    <PagerTemplate>
                        <uc:GridViewPager ID="gvPager" runat="server" OnGridViewPageIndexChanged="gvPageIndexChangedEventHandler" />
                    </PagerTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
