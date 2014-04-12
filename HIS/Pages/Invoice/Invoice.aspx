<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Invoice.aspx.cs" Inherits="HIS.Pages.Invoice.Invoice" %>

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
                                                    <asp:TextBox ID="inv_cust_id" runat="server" Width="20px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="inv_cust_name" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Recipient:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_resp" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_address" runat="server" Width="325px"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span>Site Add:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_siteadd" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_add2" runat="server" Width="180px"></asp:TextBox>
                                                    City :
                                                    <asp:TextBox ID="txt_inv_city" runat="server" Style="width: 100px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_siteadd2" runat="server" Style="width: 180px;"></asp:TextBox>City:
                                                    <asp:TextBox ID="txt_inv_sitecity" runat="server" Style="width: 89px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Postal:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_postal" runat="server" Style="width: 160px;"></asp:TextBox>
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
                                                    <asp:TextBox ID="txt_inv_sitepos" runat="server" Style="width: 139px;"></asp:TextBox>
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
                                                    <asp:TextBox ID="txt_inv_contact" runat="server" Style="width: 325px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span> Contact:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_sitecon" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tel:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_tel" runat="server" Style="width: 140px;"></asp:TextBox>
                                                    &nbsp; HP &nbsp;
                                                    <asp:TextBox ID="txt_inv_Hp" runat="server" Style="width: 142px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <span style="color: #c00;">*</span> Tel:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_sitetel" runat="server" Style="width: 130px;"></asp:TextBox>
                                                    &nbsp; HP &nbsp;
                                                    <asp:TextBox ID="txt_inv_sitehp" runat="server" Style="width: 130px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Fax No:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_fax" runat="server" Style="width: 160px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Fax No:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_sitefax" runat="server" Style="width: 160px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email Add:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_email" runat="server" Style="width: 325px;"></asp:TextBox>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Email Add:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_inv_siteemail" runat="server" Style="width: 305px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cust PO #:
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txt_inv_cust" runat="server" Style="width: 325px;"></asp:TextBox>
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
                                            <dtc1:DateSelectControl ID="inv_createddate" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Created By:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_inv_created" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span style="color: #c00;">*</span> Sales By:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="inv_salesby">
                                                <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Quote Ref No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_inv_qutrefno" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Inv Ref No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_inv_invrefno" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span style="color: #c00;">*</span> Installation date:
                                        </td>
                                        <td style="padding-left: 2px;">
                                            <dtc1:DateSelectControl ID="dsc_inv_install" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Installation Time:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_inv_time" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> Installation By:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_inv_by" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 45%;">
                                            <span>&nbsp;</span> RoundUp Qty to:
                                        </td>
                                        <td style="padding-left: 2px;">
                                            <asp:DropDownList ID="ddl_inv_round" runat="server" Style="width: 70px;">
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
                                                    <asp:TextBox runat="server" ID="inv_instal_rmk" Width="740px" TextMode="MultiLine"
                                                        Height="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top">
                                                    Remark
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox runat="server" ID="inv_rmk" Width="740px" Height="75px" TextMode="MultiLine"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ddl_inv_Dep_to" runat="server">
                                                        <asp:ListItem Text="Select Bank" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Receive By:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_inv_rec_bnk" runat="server">
                                                        <asp:ListItem Text="Select Bank" Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date Receive:
                                                </td>
                                                <td>
                                                    <dtc1:DateSelectControl ID="dsc_inv_receive" runat="server" />
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
                                                Internal Remark
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
                                    <div id="Div1" style="padding-top: 10px;">
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
    <div style="text-align: right;">
        <table style="width: 92%;">
            <tr>
                <td style="float: right;">
                    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="button_blue"
                        OnClientClick="return addItem(1);" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <asp:GridView runat="server" ID="gvinvItem" Width="750px" AutoGenerateColumns="false"
                        AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_id" runat="server" Text='1' CssClass="editableGridRow">
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
                                    <asp:TextBox ID="inv_item_Header" runat="server" Text='<%# Eval("Header") %>'
                                        CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_model" runat="server" Text='<%# Eval("Model") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_type" runat="server" Text='<%# Eval("Type") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_desc" runat="server" Text='<%# Eval("Description") %>'
                                        CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Width">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_width" runat="server" Text='<%# Eval("Width") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Height">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_height" runat="server" Text='<%# Eval("Height") %>'
                                        CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ctrl">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_ctrl" runat="server" Text='<%# Eval("Ctrl") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Set">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_setno" runat="server" Text='<%# Eval("Set") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_uom" runat="server" Text='<%# Eval("UOM") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Coloum">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_col" runat="server" Text='<%# Eval("Coloumn") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_qty" runat="server" Text='<%# Eval("Qty") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_amt" runat="server" Text='<%# Eval("UnitPrice") %>'
                                        CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="inv_item_tamt" runat="server" Text='<%# Eval("TotalAmount") %>'
                                        CssClass="editableGridRow">
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
    <br />
    <div style="text-align: right;">
        <table style="width: 92%;">
            <tr>
                <td style="float: right;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button_blue" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divoverlaypopup" class="jqoverlaypopup" style="display: none;" runat="server">
    </div>
    <div id="divPopUp" class="jqlightboxpopup" style="display: none;" runat="server">
        <div id="imgclose" style="border: 0px solid red; width: 20px; float: right; height: 20px;
            position: absolute; top: 4px; right: 12px; cursor: pointer;">
            <a onclick="javascript:return addItem(0)">
                <img src="../../Images/pop_close.gif"></a>
        </div>
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
                                Add Purchase Item
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
                    <div id="Div2" style="padding-top: 10px; padding-left: 10px;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2" style="vertical-align: top; width: 118px;">
                                    <asp:CheckBox ID="chkHide" runat="server" Text="Hide the item" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Header
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHeader" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Model
                                </td>
                                <td>
                                    <asp:TextBox ID="txtModel" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Type
                                </td>
                                <td>
                                    <asp:TextBox ID="txtType" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesc" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Width
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWidth" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Height
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHeight" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ctrl
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCtrl" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Set
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSet" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    UOM
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUOM" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Coloumn
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCol" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Qty
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Price
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUnitPrice" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Total Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div style="text-align: right;">
                        <asp:CheckBox ID="chkAddAnother" runat="server" Text="Add Another Item" />&nbsp;
                        <asp:Button ID="btnAdd" runat="server" Text="Save Item" OnClick="btnAdd_Click" />
                    </div>
                    <br />
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
    </div>
    <asp:HiddenField ID="hdnInvoice_id" runat="server" />
    <script type="text/javascript">
        function addItem(val) {
            debugger;
            if (val == 1) {
                document.getElementById('MainContent_divoverlaypopup').style.display = 'block';
                document.getElementById('MainContent_divPopUp').style.display = 'block';
            }
            else if (val == 0) {
                document.getElementById('MainContent_divoverlaypopup').style.display = 'none';
                document.getElementById('MainContent_divPopUp').style.display = 'none';
            }
            return false;
        }
    </script>
</asp:Content>
