<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QuotationAddEdit.aspx.cs" Inherits="HIS.Pages.Quotation.QuotationAddEdit" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div width="98%">
        <div>
            <table style="padding-left: 10px; width: 99%">
                <tr>
                    <td>
                        <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width: 98%">
                <tr>
                    <td>
                        <asp:Panel ID="pnlCustomer" runat="server">
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
                                                    Customer
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
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        Customer:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_id" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="quote_cust_name" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Salutation:
                                                    </td>
                                                    <td>
                                                        Family Name:
                                                    </td>
                                                    <td colspan="2">
                                                        Middle Name:
                                                    </td>
                                                    <td colspan="2">
                                                        Given Name:
                                                    </td>
                                                    <td>
                                                        Name:
                                                    </td>
                                                    <td>
                                                        Seq:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="quote_cust_emp_name_salutation">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_name_family" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="quote_cust_emp_name_middle" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="quote_cust_emp_name_given" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_name" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="quote_cust_emp_name_seq" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Tel No:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_tel" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Ext:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_tel_ext" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Hp No:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_hp" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Fax No:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_fax" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Email Add:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_emp_email" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Cust Ref:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cust_ref" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Subject:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_subject" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        Validity:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_validty" runat="server"></asp:TextBox>Days
                                                    </td>
                                                    <td>
                                                        Terms:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_terms" runat="server"></asp:TextBox>% Deposit
                                                    </td>
                                                    <td>
                                                        Delivery:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_deliver" runat="server"></asp:TextBox>
                                                        <asp:DropDownList ID="quote_deliver_sel" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        1st Reminder:
                                                    </td>
                                                    <td>
                                                        <dtc1:DateSelectControl ID="quote_reminder1" runat="server" />
                                                    </td>
                                                    <td>
                                                        2nd Reminder:
                                                    </td>
                                                    <td>
                                                        <dtc1:DateSelectControl ID="quote_reminder2" runat="server" />
                                                    </td>
                                                    <td>
                                                        Confident Level:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="quote_confident_lvl" runat="server">
                                                            <asp:ListItem Text=" " Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="25%" Value="25%"></asp:ListItem>
                                                            <asp:ListItem Text="50%" Value="50%"></asp:ListItem>
                                                            <asp:ListItem Text="75%" Value="75%"></asp:ListItem>
                                                            <asp:ListItem Text="100%" Value="100%"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Quote - Rmk:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_remark" runat="server"></asp:TextBox>
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
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Panel ID="Panel1" runat="server">
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
                                                    Details
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                                        background-repeat: no-repeat">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr4">
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_left_mid.gif');
                                        background-repeat: no-repeat">
                                    </td>
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_centre_mid.gif')">
                                        <div id="Div2">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Status:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="quote_statusid">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Replied Date:
                                                    </td>
                                                    <td>
                                                        <dtc1:DateSelectControl ID="quote_replieddate" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Quote By:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="quote_by">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Assist By:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="quote_by2">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Quote Date:
                                                    </td>
                                                    <td>
                                                        <dtc1:DateSelectControl ID="quote_date" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Invoice No:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="inv_num" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Work Order:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="wo_id" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Total Cost:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_cost" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Margin:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_margin" runat="server"></asp:TextBox>
                                                        <asp:TextBox ID="quote_margin_pctg" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Exchange Rate:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="quote_rate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                                        background-repeat: no-repeat">
                                    </td>
                                </tr>
                                <tr id="tr5" class="initalHide">
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
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 70%">
                        <asp:Panel ID="pnlAddress" runat="server">
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
                                                    Address
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                                        background-repeat: no-repeat">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr1">
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_left_mid.gif');
                                        background-repeat: no-repeat">
                                    </td>
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_centre_mid.gif')">
                                        <div id="DeliveryAddress">
                                            <table>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address:
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox runat="server" ID="quote_des_add1" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox runat="server" ID="quote_des_add2" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Postal Code:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="quote_des_add3" Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                    <td>
                                                        City:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="quote_des_add4" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Country:
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:DropDownList ID="quote_des_add5" runat="server" Width="355px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                                        background-repeat: no-repeat">
                                    </td>
                                </tr>
                                <tr id="trDABtm" class="initalHide">
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
                        </asp:Panel>
                        <asp:Panel ID="pnlSiteAddress" runat="server">
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
                                                    Site Address
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                                        background-repeat: no-repeat">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr2">
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_left_mid.gif');
                                        background-repeat: no-repeat">
                                    </td>
                                    <td style="vertical-align: bottom; background-image: url('../../Images/table_centre_mid.gif')">
                                        <div id="Div1">
                                            <table>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="f_getsite_add" Text="Same as billing Address" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address:
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox runat="server" ID="quote_site_add1" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox runat="server" ID="quote_site_add2" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Postal Code:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="quote_site_add3" Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                    <td>
                                                        City:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="quote_site_add4" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Country:
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:DropDownList ID="quote_site_add5" runat="server" Width="355px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                                        background-repeat: no-repeat">
                                    </td>
                                </tr>
                                <tr id="tr3" class="initalHide">
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
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="quote_total" Text="Sum Amt?" runat="server" />
                    </td>
                    <td style="width: 7px">
                    </td>
                    <td>
                        <asp:CheckBox ID="quote_showGST" Text="Show GST" runat="server" />
                    </td>
                    <td style="width: 7px">
                    </td>
                    <td>
                        <asp:CheckBox ID="quote_us" Text="Show Letter-Head" runat="server" />
                    </td>
                    <td style="width: 7px">
                    </td>
                    <td>
                        Warranty:
                    </td>
                    <td>
                        <asp:DropDownList ID="quote_wrty" runat="server" Width="355px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 7px">
                    </td>
                    <td>
                        TNC:
                    </td>
                    <td>
                        <asp:DropDownList ID="quote_tnc" runat="server" Width="355px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:GridView runat="server" ID="gvQuoteItem" Width="96%" AutoGenerateColumns="false"
                            AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                            <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                            <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_id" runat="server" Text='<%# Eval("quote_item_id") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Header">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="quote_item_header" runat="server" Text='<%# Eval("quote_item_header") %>'
                                            CssClass="editableGridRow">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_model" runat="server" Text='<%# Eval("quote_item_model") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Width">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_width" runat="server" Text='<%# Eval("quote_item_width") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Height">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_hight" runat="server" Text='<%# Eval("quote_item_hight") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Set">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_setno" runat="server" Text='<%# Eval("quote_item_setno") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_desc" runat="server" Text='<%# Eval("quote_item_desc") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_qty" runat="server" Text='<%# Eval("quote_item_qty") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Cost">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_vcost" runat="server" Text='<%# Eval("quote_item_vcost") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Price">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_amt" runat="server" Text='<%# Eval("quote_item_amt") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_tamt" runat="server" Text='<%# Eval("quote_item_tamt") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Margin">
                                    <ItemTemplate>
                                        <asp:TextBox ID="quote_item_margin" runat="server" Text='<%# Eval("quote_item_margin") %>'
                                            CssClass="editableGridRow">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--<EmptyDataRowStyle CssClass="hide" />--%>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 59%">
                        <table>
                            <tr>
                                <td>
                                    Salesman Rmk:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="quote_sales_rmk" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Rej Rmk:" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="quote_rejectreason" Width="250px" TextMode="MultiLine"
                                        Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Int Rmk:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="quote_inrmk" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1%">
                    </td>
                    <td style="width: 40%">
                        <table>
                            <tr>
                                <td colspan="3">
                                    No of Items:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtItemCount" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Gross Amount:
                                </td>
                                <td>
                                    <asp:DropDownList ID="quote_curr" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="quote_amt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    GST:
                                </td>
                                <td>
                                    <asp:DropDownList ID="quote_gst_pencentage" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Amount
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="quote_gst"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    Total Amount:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtQTTotalAmt"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        Total in Words:
                        <asp:TextBox runat="server" ID="txtTotAmtWords"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td>
                                    Calculation Based on:
                                </td>
                                <td>
                                    <asp:DropDownList ID="f_measurement" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 7px">
                                </td>
                                <td>
                                    RoundUp Qty to:
                                </td>
                                <td>
                                    <asp:DropDownList ID="f_qty_roundup" runat="server">
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    Decimal place
                                </td>
                                <td style="width: 7px">
                                </td>
                                <td>
                                    Calculation Formula:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="f_formular"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="button_blue" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:HiddenField ID="hdnQuote_id" runat="server" />
    </div>
</asp:Content>
