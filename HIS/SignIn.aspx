<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="HIS.SignIn" %>

<%@ Register Src="~/UserControl/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="ucMsg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Harmony In-House System</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="Stylesheet" href="../App_Themes/his/layout.css" type="text/css" media="screen" />
    <link />
</head>
<body>
    <form id="form1" runat="server">
    <div class="black_strip_login">
    </div>
    <div id="header_login" style="background: none;">
        <div id="loginheader" align="left" style="height: 129px;">
            <div class="row1" id="div_headertop" runat="server">
                <p class="logo">
                    &nbsp;
                </p>
            </div>
        </div>
    </div>
    <div id="wrapper_bg">
        <div id="wrapper_login" style="background: none;">
            <div id="login_contn">
                <div class="log_mainn">
                    <p class="log_topn">
                    </p>
                    <p class="log_leftn">
                    </p>
                    <div class="log_middlen" style="height: 350px;">
                        <div class="logleft_colu" style="margin-left: 235px;">
                            <div class="log_signin">
                                <ul>
                                    <li>
                                        <div>
                                            <p class="signin" style="height: 40px; width: 125px;">
                                                Signin
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
                                                    User Name</label>
                                            </p>
                                            <p class="column2">
                                                <asp:TextBox ID="txtUserName" runat="server" onblur="if(this.value=='')this.value='';"
                                                    class="text_field_login" onkeypress="onkeyevt();" onclick="if(this.value=='Enter Username here')this.value='';"
                                                    ForeColor="#333"></asp:TextBox>
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="rowsignn">
                                            <p class="txt_column1" style="padding-left: 1px">
                                                <label>
                                                    Password</label>
                                            </p>
                                            <p class="column2">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="text_field_login"
                                                    onpaste="return false;" onkeypress="onkeyevt();" AutoCompleteType="Disabled"></asp:TextBox>
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <br />
                                        <p class="btn_sign">
                                            <%--<asp:Button ID="btnCancel" runat="server" Text="cancel" class="button_blue" />--%>
                                            <asp:Button ID="bntLogin" runat="server" Text="Login" class="button_blue" OnClientClick="return Validate();"
                                                OnClick="btnLogin_Click" />
                                            <br />
                                            <br />
                                        </p>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <p class="log_rightn">
                    </p>
                    <p class="log_bottomn">
                    </p>
                </div>
            </div>
        </div>
    </div>
    <footer>
            <h2>© 2013 Harmony Furnishing Pte Ltd</h2>
        </footer>
    </form>
</body>
</html>
