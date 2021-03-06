﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Payment.aspx.cs" Inherits="HIS.Pages.Quotation.Payment" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .editableGridRow
        {
            width: 72px !important;
        }
    </style>
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
        <table style="width: 100%">
            <tr>
                <td style="width: 70%;">
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
                                        <table>
                                            <tr>
                                                <td>
                                                    Customer:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="pymnt_cust_id" runat="server" Width="20px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="pymnt_cust_name" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Recipient:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_resp" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_address" runat="server" Width="325px"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span>Site Add:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_siteadd" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_add2" runat="server" Width="180px"></asp:TextBox>
                                                    City :
                                                    <asp:TextBox ID="txt_pymnt_city" runat="server" Style="width: 100px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_siteadd2" runat="server" Style="width: 180px;"></asp:TextBox>City:
                                                    <asp:TextBox ID="txt_pymnt_sitecity" runat="server" Style="width: 89px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Postal:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_postal" runat="server" Style="width: 160px;"></asp:TextBox>
                                                    &nbsp;Country:
                                                    <asp:DropDownList ID="ddl_Country" runat="server" Style="width: 103px;">
                                                        <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Postal:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_sitepos" runat="server" Style="width: 139px;"></asp:TextBox>
                                                    &nbsp;Country:
                                                    <asp:DropDownList ID="ddl_sitecountry" runat="server" Style="width: 103px;">
                                                        <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Contact:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_contact" runat="server" Style="width: 325px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span> Contact:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_sitecon" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tel:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_tel" runat="server" Style="width: 140px;"></asp:TextBox>
                                                    &nbsp; HP &nbsp;
                                                    <asp:TextBox ID="txt_pymnt_Hp" runat="server" Style="width: 142px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span> Tel:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_sitetel" runat="server" Style="width: 130px;"></asp:TextBox>
                                                    &nbsp; HP &nbsp;
                                                    <asp:TextBox ID="txt_pymnt_sitehp" runat="server" Style="width: 130px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Fax No:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_fax" runat="server" Style="width: 160px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Fax No:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_sitefax" runat="server" Style="width: 160px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email Add:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_email" runat="server" Style="width: 325px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Email Add:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_pymnt_siteemail" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cust PO #:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_pymnt_cust" runat="server" Style="width: 325px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    &nbsp;
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
                <td style="width: 1%;">
                </td>
                <td style="width: 29%;">
                    <table style="width: 100%; background: #dcdcdc; border: solid 1px #000; padding: 5px;">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Created On:
                                        </td>
                                        <td style="padding-left: 2px;">
                                            <dtc1:DateSelectControl ID="pymnt_createddate" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Created By:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_pymnt_created" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span style="color: #c00;">*</span> Sales By:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="pymnt_salesby">
                                                <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Quote Ref No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_pymnt_qutrefno" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Inv Ref No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_pymnt_invrefno" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span style="color: #c00;">*</span> Installation date:
                                        </td>
                                        <td style="padding-left: 2px;">
                                            <dtc1:DateSelectControl ID="dsc_pymnt_install" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Installation Time:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_pymnt_time" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Installation By:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_pymnt_by" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> RoundUp Qty to:
                                        </td>
                                        <td style="padding-left: 2px;">
                                            <asp:DropDownList ID="ddl_pymnt_round" runat="server" Style="width: 70px;">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            Decimal place
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
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
                                                <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')" />
                                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')"
                                                    style="display: none" />
                                                Installation Rmk / Deposit
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
                                                <td style="vertical-align: top">
                                                    Installation Remark:
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox runat="server" ID="purord_instal_rmk" Width="740px" TextMode="MultiLine"
                                                        Height="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top">
                                                    Remark
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox runat="server" ID="purord_rmk" Width="740px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    Deposite Received
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Deposite To:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_purord_Dep_to" runat="server">
                                                        <asp:ListItem Text="Select Bank" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Receive By:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_purord_rec_bnk" runat="server">
                                                        <asp:ListItem Text="Select Bank" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date Receive:
                                                </td>
                                                <td>
                                                    <dtc1:DateSelectControl ID="dsc_purord_receive" runat="server" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Cheque No:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtChqNo" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="color: #c00;">
                                                    Invoice have been created can't edit
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Rec Amount:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRecAmount" runat="server"></asp:TextBox>
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
                                                <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')" />
                                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')"
                                                    style="display: none" />
                                                IntRmk
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
                                                <td style="vertical-align: top; width: 118px;">
                                                    Internal Remark
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIntRmks" runat="server" Width="740px" Height="140px" TextMode="MultiLine">
                                                    </asp:TextBox>
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
                    <asp:GridView runat="server" ID="gvpymntItem" Width="750px" AutoGenerateColumns="false"
                        AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_id" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hide">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkHide" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Header">
                                <ItemTemplate>
                                    <asp:DropDownList ID="pymnt_item_header" runat="server" Text='<%# Eval("id") %>'
                                        CssClass="editableGridRow">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_model" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_type" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_desc" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_width" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Height">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_hight" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ctrl">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_hight" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Set">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_setno" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_uom" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Coloum">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_col" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_qty" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_amt" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="pymnt_item_tamt" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <tr class="InsertUpdateDeleteGridheader" style="width: 807px;">
                                <th scope="col">
                                    &nbsp;
                                </th>
                                <th scope="col">
                                    Hide
                                </th>
                                <th scope="col">
                                    Header
                                </th>
                                <th scope="col">
                                    Model
                                </th>
                                <th scope="col">
                                    Type
                                </th>
                                <th scope="col">
                                    Description
                                </th>
                                <th scope="col">
                                    Width
                                </th>
                                <th scope="col">
                                    Height
                                </th>
                                <th scope="col">
                                    Ctrl
                                </th>
                                <th scope="col">
                                    Set
                                </th>
                                <th scope="col">
                                    UOM
                                </th>
                                <th scope="col">
                                    Coloum
                                </th>
                                <th scope="col">
                                    Qty
                                </th>
                                <th scope="col">
                                    Unit Price
                                </th>
                                <th scope="col">
                                    Total Amount
                                </th>
                            </tr>
                        </EmptyDataTemplate>
                        <%--<EmptyDataRowStyle CssClass="hide" />--%>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td style="float: right;">
                    <asp:Button ID="btnSave" runat="server" Text="Save Payment" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnPurchase_id" runat="server" />
</asp:Content>
