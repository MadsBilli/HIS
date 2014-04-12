<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchaseInvoice.aspx.cs" Inherits="HIS.Pages.PurchaseInvoice.PurchaseInvoice" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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
                <td>
                    <asp:Panel ID="pnlInVoice" runat="server">
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
                                                <%--<img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')"
                                                    style="display: none" />
                                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" />--%>
                                                Invoice
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                                    background-repeat: no-repeat">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: bottom; background-image: url('../../Images/table_left_mid.gif');
                                    background-repeat: no-repeat">
                                </td>
                                <td style="vertical-align: bottom; background-image: url('../../Images/table_centre_mid.gif')">
                                    <div id="divInvoiceDetails">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                Purchase From<br />
                                                                <asp:DropDownList ID="ddlPurchaseFrom1" runat="server" Width="250px">
                                                                    <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="PurchaseFrom" Value="PurchaseFrom"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlPurchaseFrom2" runat="server" Width="100px">
                                                                    <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="PurchaseFrom" Value="PurchaseFrom"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="TextBox1" runat="server" Width="350px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                PO No.
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPONumber" runat="server" Width="150px">
                                                                    <asp:ListItem Text="- Select -" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="pur-12345" Value="pur-12345"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Invoice
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtInvoice" Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Date
                                                            </td>
                                                            <td>
                                                                <dtc1:DateSelectControl ID="InvoiceDate" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <table width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="button_blue"
                                                        OnClientClick="return addItem(1);" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divInvoiceGrid" style="height: 200px;">
                                        <asp:GridView runat="server" ID="gvInvoice" Width="96%" AutoGenerateColumns="false"
                                            AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                                            <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                                            <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Invoice" DataField="Invoice" />
                                                <asp:BoundField HeaderText="Order" DataField="Order" />
                                                <asp:BoundField HeaderText="Re" DataField="Re" />
                                                <asp:BoundField HeaderText="Unit" DataField="Unit" />
                                                <asp:BoundField HeaderText="Desc" DataField="Desc" />
                                                <asp:BoundField HeaderText="Price" DataField="Price" />
                                                <asp:BoundField HeaderText="Tax" DataField="Tax" />
                                                <asp:BoundField HeaderText="GST" DataField="GST" />
                                                <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                                <asp:BoundField HeaderText="Acc Code" DataField="AccCode" />
                                                <asp:BoundField HeaderText="Supplier" DataField="Supplier" />
                                                <asp:BoundField HeaderText="Rec" DataField="Rec" />
                                                <asp:BoundField HeaderText="Invoice Number" DataField="InvoiceNumber" />
                                                <asp:BoundField HeaderText="WOID" DataField="WOID" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <tr class="InsertUpdateDeleteGridheader" style="width: 807px;">
                                                    <th scope="col">
                                                        Invoice
                                                    </th>
                                                    <th scope="col">
                                                        Order
                                                    </th>
                                                    <th scope="col">
                                                        Re
                                                    </th>
                                                    <th scope="col">
                                                        Unit
                                                    </th>
                                                    <th scope="col">
                                                        Desc
                                                    </th>
                                                    <th scope="col">
                                                        Price
                                                    </th>
                                                    <th scope="col">
                                                        Tax
                                                    </th>
                                                    <th scope="col">
                                                        GST
                                                    </th>
                                                    <th scope="col">
                                                        Amount
                                                    </th>
                                                    <th scope="col">
                                                        Acc Code
                                                    </th>
                                                    <th scope="col">
                                                        Supplier
                                                    </th>
                                                    <th scope="col">
                                                        Rec
                                                    </th>
                                                    <th scope="col">
                                                        Invoice Number
                                                    </th>
                                                    <th scope="col">
                                                        WOID
                                                    </th>
                                                </tr>
                                            </EmptyDataTemplate>
                                            <%--<EmptyDataRowStyle CssClass="hide" />--%>
                                        </asp:GridView>
                                    </div>
                                    <div id="divInvoiceTotal">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Filled All Acct
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFilledAllAcct" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Default Material Cost Acc Code&nbsp;<asp:TextBox ID="txtDefaultMaterialCode" runat="server">5050</asp:TextBox>
                                                </td>
                                                <td>
                                                    Sub Total
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSubTotal" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Enable Auto GST Input<asp:CheckBox ID="chkAutoGST" runat="server" Checked="true" />
                                                </td>
                                                <td>
                                                    GST
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGST" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Balance Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBalanceAmount" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
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
                </td>
            </tr>
        </table>
        <div id="divSave">
            <table width="100%">
                <tr>
                    <td>
                        Tracking Number &nbsp;
                        <asp:TextBox ID="txtTrackingNumber" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnPost" runat="server" Text="Post" CssClass="button_blue" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
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
                                <td>
                                    Invoice
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Order
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrder" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Re
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRe" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUnit" runat="server" Style="width: 90%;"></asp:TextBox>
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
                                    Price
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tax
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTax" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    GST
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGSTNo" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    AccCode
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccCode" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Supplier
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSupplier" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rec
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRec" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    InvoiceNumber
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvoiceNumber" runat="server" Style="width: 90%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    WOID
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWOID" runat="server" Style="width: 90%;"></asp:TextBox>
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
    <asp:HiddenField ID="hdnInvoiceId" runat="server" />
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
