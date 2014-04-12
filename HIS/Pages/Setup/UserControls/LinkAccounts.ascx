<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkAccounts.ascx.cs" Inherits="HIS.Pages.Setup.UserControls.LinkAccounts" %>
<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<table>
    <tr>
        <td>
            <asp:RadioButtonList ID="rdbLnkAccts" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" CssClass="pagesubtitle">
                <asp:ListItem Text="Vendors & Purchases" Value="1"></asp:ListItem>
                <asp:ListItem Text="Customers & Sales" Value="2"></asp:ListItem>
                <asp:ListItem Text="Realiized Exchange Gain/Loss" Value="3"></asp:ListItem>
                <asp:ListItem Text="Stock Closing/Opening Account" Value="4"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<br />
<table style="width: 55%;" id="MainDiv">
    <tr>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_left.gif); background-repeat: no-repeat">&nbsp;
        </td>
        <td style="width: 98%; height: 24px; vertical-align: baseline; background-image: url(../../Images/table_top_mid.gif);">
            <table>
                <tr>
                    <td class="legend">
                        <span id="legend">Payables Linked Accounts</span>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif); background-repeat: no-repeat">&nbsp; 
        </td>
    </tr>
    <tr>
        <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif); background-repeat: no-repeat"></td>
        <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif); padding: 20px">
            <div>
                <table style="padding-left: 10px; width: 99%">
                    <tr>
                        <td>
                            <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="div1">
                <fieldset>
                    <legend>General</legend>
                    <table>
                        <tr>
                            <td>Principal Bank Account for SGD: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlBankAccount" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Accounts Payable: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlPayable" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Other Payable: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlPayableOTH" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Freight Expense: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlFrieght" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Purchase Discount: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <input type="text" id="txtDiscount" style="width: 250px" /></td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Save" OnClientClick="return saveVendorsPurchases();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="div2">
                <fieldset>
                    <legend>General</legend>
                    <table>
                        <tr>
                            <td>Principal Bank Account for SGD: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlBankAccForCus" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Accounts Receivable: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlReceivable" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Other Receivable: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlReceivableOTH" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Freight Revenue: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlFreightRevenue" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Sales Discount: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlSalesDiscount" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
                <fieldset>
                    <legend>Bank Charges Account</legend>
                    <br />
                    <table>
                        <tr>
                            <td style="width:196px">Bank Charges: </td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlBankCharges" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Save" OnClientClick="return saveCustomerSales();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="div3">
                <fieldset>
                    <legend>General</legend>
                    <table>
                        <tr>
                            <td>Realized Exchange Gain/Loss</td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlExchangeGainLoss" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return saveExchangeGainOrLoss();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="div4">
                <fieldset>
                    <legend>General</legend>
                    <table>
                        <tr>
                            <td>Closing Stock Account</td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlClosingStock" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Opening Stock Account</td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlOpeningStock" style="width: 250px">
                                    <option value=""></option>
                                </select></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Inventory Stock Transfer Account</td>
                            <td style="width: 10px">&nbsp;</td>
                            <td>
                                <select id="ddlInventoryStock" style="width: 250px">
                                    <option value=""></option>
                                </select><br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Save" OnClientClick="return saveOpenClosingStock();" />
                            </td>
                        </tr>
                    </table>
                </div>
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

