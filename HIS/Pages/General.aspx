<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="General.aspx.cs" Inherits="HIS.General" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper_general_bg">
        <div id="wrapper_general" style="background: none;">
            <div id="general_contn">
                <div class="gen_mainn">
                    <div class="gen_middlen" style="height: 350px;">
                        <div class="genleft_colu" style="margin-left: 235px;">
                            <div class="gen_signin">
                                <ul>
                                    <li>
                                        <div>
                                            <p class="signin" style="height: 20px; width: 250px;">
                                                Module Listing
                                            </p>
                                        </div>
                                        <div>
                                            <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px;">
                                                <label>
                                                    General</label>&nbsp;<asp:CheckBox ID="chkGeneral" runat="server" Enabled="false" />
                                            </p>
                                            <p class="column2">
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Finance</label>&nbsp;<asp:CheckBox ID="chkFinance" runat="server" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Vendor & Purchases</label>&nbsp;<asp:CheckBox ID="chkVenPur" runat="server" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Customer & Sales</label>&nbsp;<asp:CheckBox ID="chkCustSales" runat="server" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Management</label>&nbsp;<asp:CheckBox ID="chkManagement" runat="server" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Administrator</label>&nbsp;<asp:CheckBox ID="chkAdmin" runat="server" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <p class="signin" style="height: 20px; width: 300px;">
                                                Other Settings
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Set PO GST on</label>&nbsp;<asp:CheckBox ID="chkSetpogst" runat="server" />
                                                <asp:CheckBox ID="chkQuotegst" runat="server" Text="Set Quote GST on" TextAlign="Left"
                                                    Visible="false" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Show Signature on</label>&nbsp;<asp:CheckBox ID="chkShowSign" runat="server" />
                                                <asp:CheckBox ID="chkShowBankOn" runat="server" Visible="false" />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <br />
                                        <p class="btn_sign">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="button_blue" OnClick="btnSave_Click" />&nbsp;
                                            <asp:Button ID="btnApplyChanges" runat="server" Text="Apply Changes" class="button_blue_Long"
                                                OnClick="btnApplyChanges_Click" />
                                            <br />
                                        </p>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
