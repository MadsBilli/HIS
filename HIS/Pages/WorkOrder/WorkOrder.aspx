<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WorkOrder.aspx.cs" Inherits="HIS.Pages.WorkOrder.WorkOrder" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .editableGridRow
        {
            width: 72px !important;
        }
    </style>
    <div>
        <h2 style="color: #46a5dd">
            Work Order</h2>
    </div>
    <br />
    <div>
        <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
    </div>
    <br />
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 70%;">
                    <asp:Panel ID="pnlCustomer" runat="server">
                        <fieldset style="padding: 10px 10px 20px 10px">
                            <legend style="font-weight: bold">Customer</legend>
                            <div id="Contact">
                                <table>
                                    <tr>
                                        <td>
                                            Customer:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="wo_cust_id" runat="server" Width="20px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="wo_cust_name" runat="server" Style="width: 305px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            Recipient:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_resp" runat="server" Style="width: 305px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_address" runat="server" Width="325px"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <span style="color: #c00;">*</span>Site Add:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_siteadd" runat="server" Style="width: 305px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_add2" runat="server" Width="180px"></asp:TextBox>
                                            City :
                                            <asp:TextBox ID="txt_wo_city" runat="server" Style="width: 100px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_siteadd2" runat="server" Style="width: 180px;"></asp:TextBox>City:
                                            <asp:TextBox ID="txt_wo_sitecity" runat="server" Style="width: 89px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Postal:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_postal" runat="server" Style="width: 160px;"></asp:TextBox>
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
                                            <asp:TextBox ID="txt_wo_sitepos" runat="server" Style="width: 139px;"></asp:TextBox>
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
                                            <asp:TextBox ID="txt_wo_contact" runat="server" Style="width: 325px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <span style="color: #c00;">*</span> Contact:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_sitecon" runat="server" Style="width: 305px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tel:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_tel" runat="server" Style="width: 140px;"></asp:TextBox>
                                            &nbsp; HP &nbsp;
                                            <asp:TextBox ID="txt_wo_Hp" runat="server" Style="width: 142px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <span style="color: #c00;">*</span> Tel:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_sitetel" runat="server" Style="width: 130px;"></asp:TextBox>
                                            &nbsp; HP &nbsp;
                                            <asp:TextBox ID="txt_wo_sitehp" runat="server" Style="width: 130px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fax No:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_fax" runat="server" Style="width: 160px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            Fax No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_sitefax" runat="server" Style="width: 160px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email Add:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_email" runat="server" Style="width: 325px;"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            Email Add:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_wo_siteemail" runat="server" Style="width: 305px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Cust PO #:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txt_wo_cust" runat="server" Style="width: 325px;"></asp:TextBox>
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
                        </fieldset>
                    </asp:Panel>
                </td>
                <td style="width: 1%;">
                </td>
                <td style="width: 29%;">
                    <fieldset style="padding: 10px 10px 10px 10px">
                        <legend style="font-weight: bold">Details</legend>
                        <div>
                            <table>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Created On:
                                    </td>
                                    <td>
                                        <dtc1:DateSelectControl ID="wo_createddate" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Created By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_wo_created" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span style="color: #c00;">*</span> Sales By:
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="wo_salesby">
                                            <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Quote Ref No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_wo_qutrefno" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Inv Ref No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_wo_invrefno" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span style="color: #c00;">*</span> Installation date:
                                    </td>
                                    <td>
                                        <dtc1:DateSelectControl ID="dsc_wo_install" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Installation Time:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_wo_time" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> Installation By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_wo_by" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 45%;">
                                        <span>&nbsp;</span> RoundUp Qty to:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_wo_round" runat="server" Style="width: 70px;">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        Decimal place
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="width: 70%">
                    <br />
                    <asp:Panel ID="pnlAddress" runat="server">
                        <fieldset style="padding: 10px 10px 10px 10px">
                            <legend style="font-weight: bold">Installation Rmk / Deposit</legend>
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
                                            <asp:TextBox runat="server" ID="wo_des_add1" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox runat="server" ID="wo_des_add2" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Postal Code:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="wo_des_add3" Width="250px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10px">
                                        </td>
                                        <td>
                                            City:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="wo_des_add4" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Country:
                                        </td>
                                        <td colspan="4">
                                            <asp:DropDownList ID="wo_des_add5" runat="server" Width="355px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="pnlSiteAddress" runat="server">
                        <fieldset style="padding: 10px 10px 10px 10px">
                            <legend style="font-weight: bold">IntRmk </legend>
                            <div id="divRemarks" style="padding-top: 10px;">
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
                        </fieldset>
                    </asp:Panel>
                    <br />
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: right">
        <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="button_blue"
            OnClientClick="showAlertPopup(1); return false;" />
    </div>
    <div>
        <fieldset style="height: 330px; padding: 10px 10px 10px 10px">
            <legend style="font-weight: bold">Items</legend>
            <div style="height: 320px; overflow: auto; width: 1177px">
                <asp:GridView runat="server" ID="gvWorkOder" Width="750px" AutoGenerateColumns="false"
                    AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                    <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                    <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                    <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_id" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
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
                                <asp:DropDownList ID="wo_item_header" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_model" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_type" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_desc" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Width">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_width" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Height">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_hight" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ctrl">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_hight" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Set">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_setno" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_uom" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Coloum">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_col" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_qty" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_amt" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="wo_item_tamt" runat="server" Text='<%# Eval("id") %>' CssClass="editableGridRow">
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
            </div>
        </fieldset>
    </div>
    <br />
    <div style="text-align: right;">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button_blue" />
    </div>
    <br />
    <br />
    <asp:HiddenField ID="hdnWO_id" runat="server" />
    <div class='jqoverlaypopup' id='divOverLayPopup' runat="server" style="display: none;
        height: 170%;">
    </div>
    <div id='divPopupAlert' class='jqlightboxpopup' runat="server" style="display: none;
        width: 400px; left: 50%; top: 50%; overflow-x: hidden; padding: 5px;">
        <div style="background: #46a5dd; float: left; width: 0;">
            <h2 style="padding-top: 8px; padding-left: 5px; width: 396px;">
                Add Item
            </h2>
            <div style='float: right; cursor: pointer; height: 20px; width: 20px; position: absolute;
                right: 10px; top: 10px'>
                <a onclick="showAlertPopup(0)">
                    <img src="../../Images/pop_close.gif" alt="Close" /></a>
            </div>
        </div>
        <div id="divContent" style="width: 400px !important; height: 300px !important; overflow-x: hidden;
            margin-top: 35px;">
            <br />
            <table width="100%" style="padding-left: 10px; text-align: center">
                <tr>
                    <td>
                        Header
                    </td>
                    <td>
                        <asp:TextBox ID="txtHeader" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Model
                    </td>
                    <td>
                        <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Type
                    </td>
                    <td>
                        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Height
                    </td>
                    <td>
                        <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Width
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidth" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ctrl
                    </td>
                    <td>
                        <asp:TextBox ID="txtCtrl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Set
                    </td>
                    <td>
                        <asp:TextBox ID="txtSet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        UOM
                    </td>
                    <td>
                        <asp:TextBox ID="txtUOM" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Column
                    </td>
                    <td>
                        <asp:TextBox ID="txtColumn" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quantity
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Unit Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:CheckBox ID="chkAddAnother" runat="server" Text="Add Another Item" />&nbsp;
                        <asp:Button ID="btnItemSave" runat="server" Text="Save" CssClass="button_blue" />&nbsp;
                        <asp:Button ID="btnItemCancel" runat="server" Text="Cancel" CssClass="button_blue" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function showAlertPopup(val) {
            if (val == "1") {
                document.getElementById('MainContent_divPopupAlert').style.display = 'block';
                document.getElementById('MainContent_divOverLayPopup').style.display = 'block';
            }
            else if (val == "0") {
                document.getElementById('MainContent_divPopupAlert').style.display = 'none';
                document.getElementById('MainContent_divOverLayPopup').style.display = 'none';
            }
        }

        function copyAddress(obj) {
            //alert(obj.checked);
            if (obj.checked = true) {
                //document.getElementById('MainContent_wo_site_add1').readOnly = true;
                //document.getElementById('MainContent_wo_site_add2').readOnly = true;
                //document.getElementById('MainContent_wo_site_add3').readOnly = true;
                //document.getElementById('MainContent_wo_site_add4').readOnly = true;
                //document.getElementById('MainContent_wo_site_add5').readOnly = true;
                document.getElementById('MainContent_wo_site_add1').value = document.getElementById('MainContent_wo_des_add1').value;
                document.getElementById('MainContent_wo_site_add2').value = document.getElementById('MainContent_wo_des_add2').value;
                document.getElementById('MainContent_wo_site_add3').value = document.getElementById('MainContent_wo_des_add3').value;
                document.getElementById('MainContent_wo_site_add4').value = document.getElementById('MainContent_wo_des_add4').value;
                var DropdownList1 = document.getElementById('MainContent_wo_des_add5');
                var DropdownList2 = document.getElementById('MainContent_wo_site_add5');
                var SelectedIndex = DropdownList1.selectedIndex;
                //var SelectedValue = DropdownList1.value;
                DropdownList2.selectedIndex = SelectedIndex;
                //var SelectedText = DropdownList1.options[DropdownList.selectedIndex].text;
            }
            else {
                document.getElementById('MainContent_wo_site_add1').value = '';
                document.getElementById('MainContent_wo_site_add2').value = '';
                document.getElementById('MainContent_wo_site_add3').value = '';
                document.getElementById('MainContent_wo_site_add4').value = '';
                //document.getElementById('MainContent_wo_site_add1').readOnly = false;
                //document.getElementById('MainContent_wo_site_add2').readOnly = false;
                //document.getElementById('MainContent_wo_site_add3').readOnly = false;
                //document.getElementById('MainContent_wo_site_add4').readOnly = false;
                //document.getElementById('MainContent_quote_site_add5').readOnly = false;
                var DropdownList2 = document.getElementById('MainContent_wo_site_add5');
                DropdownList2.selectedIndex = 0;
            }
        }
    </script>
</asp:Content>
