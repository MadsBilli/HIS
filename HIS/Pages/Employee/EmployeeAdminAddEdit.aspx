<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeAdminAddEdit.aspx.cs" Inherits="HIS.Pages.Employee.EmployeeAdminAddEdit" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<%@ Register Src="~/UserControl/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/DateControl.ascx" TagName="DateSelectControl" TagPrefix="dtc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script src="EmployeeScript.js"></script>
    <div>
        <h2 style="color: #46a5dd">
            Employee Admin</h2>
    </div>
    <br />
    <div>
        <ucMsg:ValidationMessage ID="ucValidationMessage" runat="server" />
    </div>
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
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="EmployeeProfile">
                        <table>
                            <tr>
                                <td>
                                    Unit:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlE_emp_bu" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Employee Status:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlE_emp_status" runat="server" Width="150px" onchange="fillEmpID(this);">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Title:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtE_emp_title" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    Salesman Code:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtE_emp_salesman_id" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Employee ID:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtE_emp_id" runat="server" Width="358px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Direct Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtE_emp_directno" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    HP Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtE_emp_hp" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Employee Name:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtE_emp_name" runat="server" Width="358px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Email:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtE_emp_email" runat="server" Width="360px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Login Name:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtE_emp_logname" runat="server" Width="358px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Welfare Group:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlE_emp_walfare" runat="server" Width="154px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Date Join:
                                </td>
                                <td style="width: 70px">
                                    <dtc1:DateSelectControl ID="dtE_emp_date_join" runat="server" />
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
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    User Group:
                                    <asp:DropDownList ID="ddlE_emp_type" runat="server" Width="154px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkE_emp_left" Text="Left" runat="server" />
                                </td>
                                <td>
                                    Date Left
                                    <dtc1:DateSelectControl ID="dtE_emp_date_left" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr>
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
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="EmployeeDetails">
                        <table>
                            <tr>
                                <td>
                                    Adress:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txthr_emp_r_add1" runat="server" Width="378px"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Gender:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlhr_emp_gender" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Bank
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_bank" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txthr_emp_r_add2" runat="server" Width="378px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Marital Status
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_marital_status" runat="server" Width="144px"></asp:TextBox>
                                </td>
                                <td>
                                    Branch:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_bank_branch" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Postal Code:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_r_add3" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Residential Tel:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_tel" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Passport / IC No.:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_passport_ic" runat="server" Width="144px"></asp:TextBox>
                                </td>
                                <td>
                                    Bank Acc No.:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_bank_acc" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Next of Kin:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_nok" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Relationship:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_nok_relationship" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Expiry Date:
                                </td>
                                <td style="width: 124px">
                                    <dtc1:DateSelectControl ID="dthr_emp_passport_ic_expiry" runat="server" />
                                </td>
                                <td>
                                    Religion:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_religion" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Health Status:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_health" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Blood Group:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_blood_grp" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Date of Birth:
                                </td>
                                <td>
                                    <dtc1:DateSelectControl ID="dthr_emp_dob" runat="server" />
                                </td>
                                <td>
                                    Remark:
                                </td>
                                <td rowspan="2">
                                    <asp:TextBox ID="txtE_emp_rmk" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Medical History:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txthr_emp_medical_history" runat="server" Width="377px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Place of Birth:
                                </td>
                                <td>
                                    <dtc1:DateSelectControl ID="dthr_emp_pob" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr class="initalHide">
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
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%; height: 24px; vertical-align: bottom; background-image: url(../../Images/table_top_right.gif);
                    background-repeat: no-repeat">
                    &nbsp;
                </td>
            </tr>
            <tr class="initalHide">
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_left_mid.gif);
                    background-repeat: no-repeat">
                </td>
                <td style="width: 98%; vertical-align: bottom; background-image: url(../../Images/table_centre_mid.gif)">
                    <div id="EmployeePayroll">
                        <table>
                            <tr>
                                <td>
                                    Emp Age:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_emp_age" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Basic Salary:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_regular" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td colspan="2">
                                    <b>CPF Contribution</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tpt Allowance:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_fixed_allowance" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    - Empoyee:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_cpf_emp" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Amount:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_cpf_emp_amt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    SDL Fund:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_SDL" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    - Employer:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_cpf_company" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    Amount:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_cpf_company_amt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Donation:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthr_pay_donation" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    Donation Desc:
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlhr_pay_donation_desc" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%; vertical-align: bottom; background-image: url(../../Images/table_right_mid.gif);
                    background-repeat: no-repeat">
                </td>
            </tr>
            <tr class="initalHide">
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
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnShowHideLeft" Text="Hide Left" OnClick="btnShowHideLeft_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearch_emp_bu" runat="server" Width="100px" OnSelectedIndexChanged="ddlSearch_emp_bu_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="96%">
            <tr>
                <td>
                    <asp:GridView runat="server" ID="gvEmployeeList" Width="100%" AutoGenerateColumns="false"
                        AllowPaging="true" OnRowDataBound="gvEmployeeListGridRowDataBoundEneventHandler">
                        <Columns>
                            <asp:BoundField DataField="emp_id" HeaderText="Employee ID" />
                            <asp:BoundField DataField="emp_name" HeaderText="Employee Name" />
                            <asp:BoundField DataField="emp_typedesc" HeaderText="User Group" />
                            <asp:BoundField DataField="emp_salesman_id" HeaderText="Salesman ID" />
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="80">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelCustomer" runat="server" ImageUrl="~/Images/DELETE_1.GIF"
                                        ToolTip="Delete Customer" CommandArgument='<%# Eval("emp_id") %>' OnClick="DelCustomer" />
                                    <asp:ImageButton ID="imgEditCustomer" runat="server" ImageUrl="~/Images/Ico_Edit.GIF"
                                        ToolTip="Edit Customer" CommandArgument='<%# Eval("emp_id") %>' OnClick="EditCustomer" />
                                    <%--COMMENT--%>
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
</asp:Content>
