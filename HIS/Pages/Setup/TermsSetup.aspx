<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TermsSetup.aspx.cs" Inherits="HIS.Pages.Setup.TermsSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td>Term Selection</td>
                <td><asp:RadioButtonList ID="rbTermSelection" runat="server">
                    <asp:ListItem Text="Quote" Value="Quote" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>
                    </asp:RadioButtonList> </td>
            </tr>
            <tr>
                <td>Terms</td>
                <td><asp:DropDownList ID="ddlTerms" runat="server"></asp:DropDownList> </td>
                <td style="width:20px"></td>
                <td>Term Description</td>
                <td><asp:TextBox ID="txtTermDescription" runat="server"></asp:TextBox> </td>
                <td style="width:20px"></td>
                <td>Type</td>
                <td><asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td>
                     <asp:GridView runat="server" ID="gvTermsSetup" Width="96%" AutoGenerateColumns="false" AllowPaging="false" CssClass="InsertUpdateDeleteGrid"
                        OnRowDataBound="gvTermsSetupGridRowDataBoundEneventHandler">
                        <HeaderStyle CssClass="InsertUpdateDeleteGridheader" />
                        <AlternatingRowStyle CssClass="InsertUpdateDeleteGridrowAlt" HorizontalAlign="Left" />
                        <RowStyle CssClass="InsertUpdateDeleteGridrow" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="int_id" HeaderText="int_id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:BoundField DataField="intTermID" HeaderText="intTermid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:TemplateField HeaderText="LN">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_LN" runat="server" Text='<%# Eval("txtLN") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_description" runat="server" Text='<%# Eval("txtDescription") %>' CssClass="editableGridRow">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <%--<EmptyDataRowStyle CssClass="hide" />--%>
                    </asp:GridView>
                </td>
            </tr>

            <tr><td><asp:Button runat="server" ID="btnDeleteAllItem" /><asp:Button runat="server" ID="btnAddTermItem"/> </td></tr>
        </table>
    </div>
</asp:Content>
