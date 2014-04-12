<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VendorAddEdit.aspx.cs" Inherits="HIS.Pages.Vendor.VendorAddEdit" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="VendorScript.js"></script>
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
                    <asp:CheckBox ID="chkShowHideGridColumn" runat="server" Text="Show Year To Date Purchase / Balance"
                        onclick="chkShowHideGridColumn(this,4);" Checked="true" />
                </td>
                <td>
                    <asp:CheckBox ID="chkShowInactiveColumn" runat="server" Text="Inactive Vendor" onclick="chkShowHideGridColumn(this,3);"
                        Checked="true" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="98%">
            <tr>
                <td>
                    <asp:GridView runat="server" ID="gvCustomerList" Width="100%" AutoGenerateColumns="false"
                        AllowPaging="true" OnRowDataBound="gvCustomerListGridRowDataBoundEneventHandler"
                        CssClass="InsertUpdateDeleteGrid">
                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="cust_id" HeaderText="Ven ID" />
                            <asp:BoundField DataField="cust_name" HeaderText="Name" />
                            <asp:BoundField DataField="cust_inactive" HeaderText="Inactive" HeaderStyle-CssClass="hide"
                                ItemStyle-CssClass="hide" />
                            <asp:TemplateField HeaderText="Inactive" ItemStyle-Width="80" HeaderStyle-CssClass="hide"
                                ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkInactive" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="YTD_Sales" HeaderText="YTD Purchase" HeaderStyle-CssClass="hide"
                                ItemStyle-CssClass="hide" />
                            <asp:BoundField DataField="YTD_Owing" HeaderText="YTD Balance" HeaderStyle-CssClass="hide"
                                ItemStyle-CssClass="hide" />
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="80">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelCustomer" runat="server" ImageUrl="~/Images/DELETE_1.GIF"
                                        ToolTip="Delete Customer" CommandArgument='<%# Eval("cust_id") %>' OnClick="DelCustomer"
                                        OnClientClick="return Confirm();" />
                                    <asp:ImageButton ID="imgEditCustomer" runat="server" ImageUrl="~/Images/Ico_Edit.GIF"
                                        ToolTip="Edit Customer" CommandArgument='<%# Eval("cust_id") %>' OnClick="EditCustomer" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <uc:GridViewPager ID="gvPager" runat="server" OnGridViewPageIndexChanged="gvPageIndexChangedEventHandler" />
                        </PagerTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
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
                                Main
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trMainMid">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="main">
                        <table>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vendor ID:
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ReadOnly="true" runat="server" ID="txtCustomerId" Width="350px"></asp:TextBox>
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    Vendor Name:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtCustomerName" Width="190px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address:
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" ID="txtAddress1" Width="350px"></asp:TextBox>
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    Payee Name:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtPayeeName1" Width="190px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" ID="txtAddress2" Width="350px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtPayeeName2" Width="190px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Postal Code:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPostalCode" Width="152px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    City:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCity" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Credit Limit:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCreditLimit" onkeypress="return NumberOnly()"
                                        Width="70px"></asp:TextBox>
                                </td>
                                <td>
                                    Terms:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTerms" onkeypress="return NumberOnly()" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Country:
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlCountry" runat="server" Width="355px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:CheckBox ID="ChkRegisteredCompany" runat="server" Text="GST Registered Company"
                                        TextAlign="Left" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Main Contact:
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" ID="txtMainContact" Width="349px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Area Code:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTelAreaCode" Width="150px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Tel:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTel" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td colspan="4">
                                    Default Trade Debtor
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Area Code:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFaxAreaCode" Width="150px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Fax:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFax" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlDefaultTradeDebtor" runat="server" Width="375px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email:
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" ID="txtEmail" Width="349px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="10" style="width: 100%; vertical-align: bottom; background-image: url(../../Images/line.gif);">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="ChkBlacklisted" runat="server" Text="Blacklisted" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 7px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr id="trMainBtm">
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
    <div>
        <asp:Panel ID="pnlContact" runat="server">
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
                                    Contact's Details
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
                                    <td style="text-align: center">
                                        <asp:Button ID="btnprevious" runat="server" Text="<<" OnClick="btnprevious_Click" />
                                        <asp:Button ID="btnnext" runat="server" Text=">>" OnClick="btnnext_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        Gender:<asp:Label ID="lblstart1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGender" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Salutation:<asp:Label ID="lblstart2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSalutation" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        No.of Contacts:
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtNoOfContact" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Family Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFamilyName" runat="server" Width="144px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Middle Name:<asp:Label ID="lblstart3" runat="server" Text="#" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleName" runat="server" Width="134px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Given Name:<asp:Label ID="lblstart4" runat="server" Text="#" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Name Seq:<asp:Label ID="lblstart5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlNameSeq" runat="server" Width="105px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 100px">
                                        Contact Type:<asp:Label ID="lblstart6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlContactType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Level:<asp:Label ID="lblstart7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlLevel" runat="server" Width="386px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Area Code:<asp:Label ID="lblstart8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="5">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtContTelAreaCode" runat="server" Width="50px"></asp:TextBox>
                                                </td>
                                                <td style="width: 35px">
                                                    Tel:<asp:Label ID="lblstart9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtContTel" runat="server" Width="149px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Ext:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtContExt" runat="server" Width="50px"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px">
                                                    Prefer Dialog:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPreferDialog" runat="server" Width="180px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Title:<asp:Label ID="lblstart10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTitle" runat="server" Width="380px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Area Code:
                                    </td>
                                    <td colspan="5">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtHPAreaCode" runat="server" Width="50px"></asp:TextBox>
                                                </td>
                                                <td style="width: 35px">
                                                    HP:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHP" runat="server" Width="230px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Dept:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDept" runat="server" Width="380px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Area Code:
                                    </td>
                                    <td colspan="5">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtContFaxAreaCode" runat="server" Width="50px"></asp:TextBox>
                                                </td>
                                                <td style="width: 35px">
                                                    Fax:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtContFax" runat="server" Width="230px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email:<asp:Label ID="lblstart11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtContactEmail" runat="server" Width="380px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Source:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtSource" runat="server" Width="380px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Region:
                                    </td>
                                    <td colspan="5">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    BU:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBU" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <img src="../../Images/line.gif" style="width: 100%; height: 30px" />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        Address:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactAddress1" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Asst's Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstName" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Manager name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtManagerName" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactAddress2" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Area Code:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstAreaCode" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Asst's Tel:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstTel" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Ext:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstExt" runat="server" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Postal Code:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstPostalCode" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        City:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstCity" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Area Code:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstFaxAreaCode" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Other Fax:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstFax" runat="server" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Country:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAsstCountry" runat="server" Width="206px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        Email2:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstEmail2" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        Remark:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsstRemark" TextMode="MultiLine" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="vertical-align: top">
                                        <asp:Literal ID="ltcontactRelation" runat="server" Text="Contact's </br> Relationship"> </asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactRelationship" TextMode="MultiLine" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <i>Last Updated:</i>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblContUpdateBy" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="imgContactAddNew" runat="server" Text="Add New" OnClick="imgContactAddNew_Click"
                                            CssClass="button_blue" />&nbsp;
                                        <asp:Button ID="imgContactSave" runat="server" Text="Save" OnClick="imgContactSave_Click"
                                            CssClass="button_blue" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkContInactive" runat="server" Text="Inactive" />
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
            <asp:HiddenField ID="hdnCustContEmpNo" runat="server" />
            <asp:HiddenField ID="hdnNewContact" runat="server" />
        </asp:Panel>
    </div>
    <div>
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
                                Delivery Address
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trDAMid" class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="DeliveryAddress">
                        <table>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bank Name:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtBankName" Width="250px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Remarks
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bank Address:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtBankAdd1" Width="250px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td rowspan="3">
                                    <asp:TextBox ID="txtBankRemarks" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtBankAdd2" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtBankAdd3" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    Swift Code:
                                </td>
                                <td>
                                    Bank Code:
                                </td>
                                <td>
                                    Branch Code:
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtSwiftCode" Width="77px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtBankCode" Width="77px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtBranchCode" Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Routing No:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtRoutingNo" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Account No:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox runat="server" ID="txtAccountNo" Width="250px"></asp:TextBox>
                                </td>
                                <td>
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
    </div>
    <div>
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
                                Cust's Memo
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trCMMid" class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="costMemo">
                        <table>
                            <tr>
                                <td style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vendor Remark
                                </td>
                                <td style="width: 5px">
                                </td>
                                <td>
                                    Internal Remark
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCustomerRemark" TextMode="MultiLine" Width="300px"
                                        Height="70px"></asp:TextBox>
                                </td>
                                <td style="width: 30px">
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtInternalRemark" TextMode="MultiLine" Width="300px"
                                        Height="70px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="10" style="width: 100%; vertical-align: bottom; background-image: url(../../Images/line.gif);">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="info">
                                <td>
                                    Created By
                                </td>
                                <td>
                                    <asp:Label ID="lblCustCreatedBy" runat="server"></asp:Label>
                                    <asp:Label ID="lblCustCreatedOn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="info">
                                <td>
                                    Last Updated
                                </td>
                                <td>
                                    <asp:Label ID="lblLastUpdatedBy" runat="server"></asp:Label>
                                    <asp:Label ID="lblLastUpdatedOn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 7px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr id="trCMBtm" class="initalHide">
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
    <br />
    <div>
        <table style="width: 100%">
            <tr style="background-color: lightgrey">
                <td>
                    <asp:CheckBox ID="chkInactiveCustomer" Text="Inactive Account" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="imgbtnAddNew" runat="server" Text="Add New" OnClick="imgbtnAddNew_Click"
                        CssClass="button_blue" />
                    &nbsp;
                    <asp:Button ID="imgbtnSave" runat="server" Text="Save" OnClick="imgbtnSave_Click"
                        CssClass="button_blue" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <asp:HiddenField ID="hdnCustEmpNo" runat="server" />
        <asp:HiddenField ID="hdnCustNature" runat="server" />
        <asp:HiddenField ID="hdnCustPayup" runat="server" />
        <asp:HiddenField ID="hdnCustName" runat="server" />
        <asp:HiddenField ID="hdnNoOfContacts" runat="server" Value="0" />
    </div>
</asp:Content>
