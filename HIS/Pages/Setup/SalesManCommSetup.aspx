<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesManCommSetup.aspx.cs" Inherits="HIS.Pages.Setup.SalesManCommSetup" EnableEventValidation="true" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Script/SetupCommonScript.js"></script>
    <script src="Script/SalesManCommScript.js"></script>
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
                                Salesman Commission Setup
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
                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt nonInsertable" HorizontalAlign="Left" />
                            <RowStyle CssClass="InsertUpdateDeleteGridrow nonInsertable" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="emp_salesman_id" HeaderText="Salesman ID" ItemStyle-Width="100px"/>                  
                                <asp:BoundField DataField="emp_name" HeaderText="Name"/>                                                  
                                  <asp:TemplateField HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRate" runat="server" Text='<%# (Eval("emp_salesman_com")) %>' BorderStyle="None" BackColor="Transparent" Width="70px" style="text-align:center"  onkeypress='return check_digit(event,this,8,8);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>               
                                <asp:BoundField DataField="emp_id" HeaderText="Emp Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />                
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
