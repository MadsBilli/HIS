<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RptPrintingSetup.aspx.cs" Inherits="HIS.Pages.Setup.RptPrintingSetup" EnableEventValidation="true" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Script/SetupCommonScript.js"></script>
    <script src="Script/RptPrintingSetupScript.js"></script>
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
        <table style="width:85%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">
                                <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')" />
                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" style="display: none" />
                                Report Printer Setup
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
                </td>
            </tr>

            <tr>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div>                       
                        <br />
                        <asp:GridView runat="server" ID="gvList" Width="100%" AutoGenerateColumns="false" AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                            <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                            <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="Rpt Display Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDisplayName" runat="server" Text='<%# (Eval("rt_display_name")) %>' BorderStyle="None" BackColor="Transparent"  Width="250px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rpt Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("rt_name") %>' BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Rpt Record Id">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtId" runat="server" Text='<%# Eval("rt_id") %>' BorderStyle="None" BackColor="Transparent"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCriteria" runat="server" Text='<%# Eval("rt_criteria") %>' BorderStyle="None" BackColor="Transparent" Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rpt Table">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTable" runat="server" Text='<%# Eval("rt_table") %>' BorderStyle="None" BackColor="Transparent" Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                
                                <asp:BoundField DataField="primaryKey" HeaderText="PrimaryKey" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />                  
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="60">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/DELETE_1.GIF"
                                            CommandArgument='<%# Eval("primaryKey") %>' OnClick="DelItem" OnClientClick="return delItem(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>                   
                    </div>
                    <div>
                        <br />
                        <hr />
                    </div>
                    <div id="divFooter">
                        <table id="tblfooter" style="margin-left: 7px;">
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif); background-repeat: no-repeat"></td>
                <td></td>
            </tr>

            <tr>
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
        <table>
            <tr>
                <td>
                    <asp:ImageButton ID="imgbtnSave" runat="server" ImageUrl="~/Images/btn_Save.gif" OnClientClick="return save();" />
                    <asp:Button ID="btnSave" runat="server" OnClick="imgbtnSave_Click" CssClass="hide" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
