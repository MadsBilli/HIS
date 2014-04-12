<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrencySetup.aspx.cs" Inherits="HIS.Pages.Setup.CurrencySetup" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl"
    TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Script/SetupCommonScript.js"></script>
    <script src="Script/SetupCommonScriptMultipleGrid.js"></script>
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
        <table style="width: 100%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">Currency
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
                </td>
            </tr>

            <tr id="trMainMid">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="main">
                        <table>

                            <tr>
                                <td colspan="3">
                                    <br />
                                    <asp:CheckBox ID="chkAllowForeignTransaction" runat="server" Text="Allow Transactions in foreign Currency" />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="3">
                                    <br />
                                    <i>Enter home currency and the account used to track exchange differences</i></td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>Home Currency:</td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddl_f_currency_id" runat="server" Width="130px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Currency Code:</td>
                                <td>
                                    <asp:TextBox ID="txt_f_currency_code" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="width: 20px"></td>
                                <td>Thousands Separator:</td>
                                <td>
                                    <asp:DropDownList ID="ddl_f_currency_thousand_sepa" runat="server" Width="50px">
                                        <asp:ListItem Value="comma" Text=","></asp:ListItem>
                                        <asp:ListItem Value="semicolon" Text=";"></asp:ListItem>
                                        <asp:ListItem Value="space" Text=" "></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Symbol:</td>
                                <td>
                                    <asp:TextBox ID="txt_f_currency_symbol" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="width: 20px"></td>
                                <td>Decimal Separator:</td>
                                <td>
                                    <asp:DropDownList ID="ddl_f_currency_decimal_sepa" runat="server" Width="50px">
                                        <asp:ListItem Value="dot" Text="."></asp:ListItem>
                                        <asp:ListItem Value="semicolon" Text=";"></asp:ListItem>
                                        <asp:ListItem Value="comma" Text=","></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Symbol Position:</td>
                                <td>
                                    <asp:DropDownList ID="ddl_f_currency_position" runat="server" Width="130px">
                                        <asp:ListItem Value="Leading" Text="Leading"></asp:ListItem>
                                        <asp:ListItem Value="Trailing" Text="Trailing"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 20px"></td>
                                <td>Decimal Place:</td>
                                <td>
                                    <asp:DropDownList ID="ddl_f_currency_decimal_place" runat="server" Width="50px">
                                        <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Format:</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_f_currency_format" runat="server" Width="123px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">Track Exchange and Rouding Differences in:</td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddl_f_currency_gl_code" runat="server"></asp:DropDownList>
                                </td>
                                <td style="width: 20px"></td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <table style="Width: 100%">
                            <tr>
                                <td>
                                    <asp:GridView runat="server" ID="gvCurrencySetup" Width="96%" AutoGenerateColumns="false" AllowPaging="false" CssClass="InsertUpdateDeleteGrid"
                                        OnRowDataBound="gvCurrencySetupGridRowDataBoundEneventHandler">
                                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundField DataField="currency_id" HeaderText="Cust ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="Foreign Currency">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_gv_f_currency_desc" runat="server" Text='<%# Eval("currency_desc") %>' CssClass="editableGridRow">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_gv_f_currency_code" runat="server" Text='<%# Eval("currency_code") %>' CssClass="editableGridRow">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Symbol">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_gv_f_currency_symbol" runat="server" Text='<%# Eval("currency_symbol") %>' CssClass="editableGridRow">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="currency_position" HeaderText="Symbol Position" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="Symbol Position">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddl_gv_f_currency_position" runat="server">
                                                        <asp:ListItem Value="Leading" Text="Leading"></asp:ListItem>
                                                        <asp:ListItem Value="Trailing" Text="Trailing"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="currency_thousand_sepa" HeaderText="Thousand Separator" />
                                            <asp:BoundField DataField="currency_decimal_sepa" HeaderText="Decimals Separator" />
                                            <asp:BoundField DataField="currency_decimal_place" HeaderText="Decimal Place" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="Decimal Place">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddl_gv_f_currency_decimal_place" runat="server">
                                                        <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="currency_format" HeaderText="Format" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="Format">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_gv_f_currency_format" runat="server" Text='<%# Eval("currency_format") %>'>>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <%--<EmptyDataRowStyle CssClass="hide" />--%>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif); background-repeat: no-repeat"></td>
            </tr>
            <tr id="tr4">
                <td style="width: 1%">
                    <img src="../../Images/table_btm_left.gif" />
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_btm_mid.gif)"></td>
                <td style="width: 1%">
                    <img src="../../Images/table_btm_right.gif" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">Exchange Rates
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
                </td>
            </tr>

            <tr id="tr1">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="Div1">
                        <table style="width: 96%">
                            <tr>
                                <td>Currency :
                                    <asp:DropDownList ID="ddl_ex_currency_desc" runat="server"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView runat="server" ID="gvExchangeRate" AutoGenerateColumns="false" AllowPaging="false" CssClass="InsertUpdateDeleteGrid1">
                                        <HeaderStyle CssClass="InsertUpdateDelete1Grid1header" />
                                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGrid1rowAlt" HorizontalAlign="Left" />
                                        <RowStyle CssClass="InsertUpdateDeleteGrid1row" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundField DataField="currency_id" HeaderText="Cust ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_currency_rate" runat="server" Text='<%# Eval("currency_rate") %>' CssClass="editableGridRow">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Currency Date">
                                                <ItemTemplate>
                                                    <dtc1:DateSelectControl ID="dt_currency_Date" runat="server" Value='<%# Convert.ToDateTime( Eval("currency_date")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="currency_update_by" HeaderText="Updated By" />
                                            <asp:TemplateField HeaderText="Remark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_currency_rmk" runat="server" Text='<%# Eval("currency_rmk") %>' CssClass="editableGridRow">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="80">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgDelCustomer" runat="server" ImageUrl="~/Images/DELETE_1.GIF" ToolTip="Delete Customer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <%--<EmptyDataRowStyle CssClass="hide" />--%>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif); background-repeat: no-repeat"></td>
            </tr>
            <tr id="tr2">
                <td style="width: 1%">
                    <img src="../../Images/table_btm_left.gif" />
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_btm_mid.gif)"></td>
                <td style="width: 1%">
                    <img src="../../Images/table_btm_right.gif" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
