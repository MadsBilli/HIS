<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FabricCodeAddEdit.aspx.cs" Inherits="HIS.Pages.FabricCode.FabricCodeAddEdit"
    EnableEventValidation="true" %>

<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="FabricCodeScript.js"></script>
    <div>
        <h2 style="color: #46a5dd">
            Fabric Code</h2>
    </div>
    <br />
    <div>
        <table style="padding-left: 10px; width: 99%">
            <tr>
                <td>
                    <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                </td>
            </tr>
        </table>
        <table width="99%">
            <tr>
                <td>
                    Material Type: &nbsp;
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlmaterial" Width="175px" OnSelectedIndexChanged="ddlmaterial_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="width: 25px">
                </td>
                <td>
                    Price Option &nbsp;
                </td>
                <td>
                    <fieldset>
                        <asp:RadioButtonList ID="rdbPriceOption" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </fieldset>
                </td>
                <td style="width: 25px">
                </td>
                <td>
                    <asp:Button ID="btnPreview" runat="server" Text="Preview Price List" OnClick="btnPreview_Click"
                        OnClientClick="return previewPriceList();" CssClass="button_blue_ToLong" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style="width: 99%;">
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
                                Fabric
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trFabricMid">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="fabric">
                        &nbsp;To add or change a Fabric, fill in the information below.
                        <img src="../../Images/row_duplicate.png" title="duplicate" style="cursor: pointer"
                            onclick="cloneNewRow(false);" />
                        <br />
                        <br />
                        <asp:GridView runat="server" ID="gvFabricCodeRollerList" Width="100%" AutoGenerateColumns="false"
                            AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                            <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                            <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="FC-Code">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCode" runat="server" Text='<%# Eval("fc_code") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("fc_desc") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Colour">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtColor" runat="server" Text='<%# Eval("fc_colour") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Cost">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUnitCost" runat="server" Text='<%# Eval("fc_unitcost") %>' BorderStyle="None"
                                            BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chain">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice" runat="server" Text='<%# Eval("fc_unitprice") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spring">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice2" runat="server" Text='<%# Eval("fc_unitprice2") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spring Chain">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice3" runat="server" Text='<%# Eval("fc_unitprice3") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fixeas Stop Width">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice4" runat="server" Text='<%# Eval("fc_unitprice4") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chain">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice" runat="server" Text='<%# Eval("fc_instprice") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spring">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice2" runat="server" Text='<%# Eval("fc_instprice2") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spring Chain">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice3" runat="server" Text='<%# Eval("fc_instprice3") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fixeas Stop Width">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice4" runat="server" Text='<%# Eval("fc_instprice4") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max. Fabric Width">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtwidth" runat="server" Text='<%# Eval("fc_width") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="80px" CssClass="center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtrmk" runat="server" Text='<%# Eval("fc_rmk") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="60">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelFabricCode" runat="server" ImageUrl="~/Images/DELETE_1.GIF"
                                            CommandArgument='<%# Eval("primaryKey") %>' OnClick="DelFabricCode" OnClientClick="return delFabricCode(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="primaryKey" HeaderText="PrimaryKey" ItemStyle-CssClass="hide" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView runat="server" ID="gvFabricCodeList" Width="100%" AutoGenerateColumns="false"
                            AllowPaging="false" CssClass="InsertUpdateDeleteGrid">
                            <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                            <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                            <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="FC-Code">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCode" runat="server" Text='<%# Eval("fc_code") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("fc_desc") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Colour" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtColor" runat="server" Text='<%# Eval("fc_colour") %>' BorderStyle="None"
                                            BackColor="Transparent"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Cost">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUnitCost" runat="server" Text='<%# Eval("fc_unitcost") %>' BorderStyle="None"
                                            BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Size">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSize" runat="server" Text='<%# Eval("fc_size") %>' BorderStyle="None"
                                            BackColor="Transparent" CssClass="center" Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max Length">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtwidth" runat="server" Text='<%# Eval("fc_width") %>' BorderStyle="None"
                                            BackColor="Transparent" CssClass="center" Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Normal Cord String (psf)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice" runat="server" Text='<%# Eval("fc_unitprice") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="1'' Ladder    Tape (psf)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtunitprice2" runat="server" Text='<%# Eval("fc_unitprice2") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Normal Cord String (psf)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice" runat="server" Text='<%# Eval("fc_instprice") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="1'' Ladder    Tape (psf)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtinstprice2" runat="server" Text='<%# Eval("fc_instprice2") %>'
                                            BorderStyle="None" BackColor="Transparent" CssClass="numerictd" onblur='convertThisElementValueToDecimal(this);'
                                            onkeypress='return check_digit(event,this,8,3);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Additional Charges">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtrmk" runat="server" Text='<%# Eval("fc_rmk") %>' BorderStyle="None"
                                            BackColor="Transparent" Width="200px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelFabricCode" runat="server" ImageUrl="~/Images/DELETE_1.GIF"
                                            CommandArgument='<%# Eval("primaryKey") %>' OnClick="DelFabricCode" OnClientClick="return delFabricCode(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="primaryKey" HeaderText="PrimaryKey" ItemStyle-CssClass="hide" />
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
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td>
                </td>
            </tr>
            <tr id="trFabricBtm">
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
        <table style="width: 99%;">
            <tr>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
                <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
                    <table>
                        <tr>
                            <td class="legend" colspan="3">
                                <img src="../../Images/but_collapse.gif" onclick="HideAndShowUsingJQuery(this,'C')"
                                    style="display: none" />
                                <img src="../../Images/but_expand.gif" onclick="HideAndShowUsingJQuery(this,'O')" />
                                Header
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trHeaderMid" class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <br />
                    <div id="header">
                        <table>
                            <tr>
                                <td colspan="3">
                                    Header<br />
                                    <asp:TextBox ID="txtHeader" runat="server" Rows="8" Columns="100" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 250px">
                                                Minimum Qty: &nbsp;<asp:TextBox ID="txtMinQty" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                Effective Date: &nbsp;
                                            </td>
                                            <td>
                                                <dtc1:DateSelectControl ID="txtEffectiveDate" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr id="trHeaderBtm" class="initalHide">
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
        <table style="width: 99%;">
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
                                Footer
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr id="trFooterMid" class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <br />
                    <div id="footer">
                        <table>
                            <tr>
                                <td>
                                    Footer<br />
                                    <asp:TextBox ID="txtFooter" runat="server" Rows="8" Columns="100" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Remarks<br />
                                    <asp:TextBox ID="txtRemarks" runat="server" Rows="8" Columns="100" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr id="trFooterBtm" class="initalHide">
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
    <div onload="resizeGrid()">
        <table>
            <tr>
                <td>
                    <%--<asp:ImageButton ID="imgbtnSave" runat="server" CssClass="button_blue" ImageUrl="~/Images/btn_Save.gif"
                        OnClientClick="return save();" />--%>
                    <asp:Button ID="btnSave" runat="server" CssClass="button_blue" OnClientClick="return save();"
                        OnClick="imgbtnSave_Click" Text="Save" />
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
