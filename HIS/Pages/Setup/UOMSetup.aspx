<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UOMSetup.aspx.cs" Inherits="HIS.Pages.Setup.UOMSetup" EnableEventValidation="true" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Script/SetupCommonScript.js"></script>
    <script src="Script/UOMSetupScript.js"></script>
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
        <table style="width: 50%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend">
                                <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')" />
                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" style="display: none" />
                                Unit of Measurement Setup Module
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
                                <asp:TemplateField HeaderText="S/N">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtId" runat="server" Text='<%# ProcessData(Eval("unit_id")) %>' BorderStyle="None" BackColor="Transparent" Width="30px" style="text-align:center"  onkeypress='return check_digit(event,this,8,1);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtType" runat="server" Text='<%# Eval("unit_type") %>' BorderStyle="None" BackColor="Transparent" Width="75px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                 <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("unit_rmk") %>' BorderStyle="None" BackColor="Transparent" Width="150px" ></asp:TextBox>
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
