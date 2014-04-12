<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HIS.Pages.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Harmony In-House System</title>
    <link rel="stylesheet" media="screen" type="text/css" href="../App_Themes/Theme/calendar/kalendar.css" />
    <script type="text/javascript" src="../App_Themes/Theme/calendar/jquery-2.0.3.min.js"></script>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="black_strip_login">
    </div>
    <div id="header" style="background: white; height: 100px">
        <div class="logo">
        </div>
        <div style="text-align: right; padding: 5px 5px 0px 0px;">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="button_main" OnClick="btnLogout_Click" />
        </div>
    </div>
    <div id="wrapper_bg" style="padding-top: 40px;">
        <div id="wrapper_login" style="background: none;">
            <div style="float: left; padding-left: 10px;">
                <ul id="nav">
                    <div runat="server" id="main">
                    </div>
                </ul>
            </div>
            <div class="container" style="background-color: #D5D8DA">
                <div style="border: 2px none black; float: left; height: 108%; width: 715px;">
                    <h1 style="color: #46a5dd; width: 626px;">
                        Announcements</h1>
                    <p style="color: #c00; padding: 40px; padding-left: 90px; font-size: medium;">
                        <span>Harmony Furnishing is one of Singapore’s leading manufacturers of high quality
                            window furnishings. We specialize in the production of roller blinds, timber blinds,
                            faux venetian blinds, curtains and roman blinds. We offer both manual systems and
                            motorized systems for all our products. Constantly re-engineering and designing,
                            we have gained a strong reputation as having one of the best quality and reliable
                            products in the industry. </span>
                        <br />
                        <br />
                        <span>With all services under one roof, we provide a highly detailed, personalized experience.
                            As such, we are able to control costs at every stage, providing the best economical
                            solutions. We are pleased to be part of our clients’ success by offering them flexible
                            solutions. With over 20 skilled personnel in the team, we are pleased to provide
                            a complete experience for our clients. </span>
                    </p>
                </div>
            </div>
            <div style="float: right; margin-top: -460px; width: 216px;">
                <div class="example">
                </div>
            </div>
            <footer>
            <h2>© 2013 Harmony Furnishing Pte Ltd</h2>
        </footer>
        </div>
    </div>
    </form>
    <script src="../App_Themes/Theme/calendar/kalendar.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.example').kalendar({
                events: [
			{
			    title: "Harmony In-House System",
			    start: {
			        date: "YYYYMMDD",
			        time: "HH.MM"
			    },
			    end: {
			        date: "YYYYMMDD",
			        time: "HH.MM"
			    },
			    location: "Singapore"
			}
		],
                color: "blue",
                firstDayOfWeek: "Sunday",
                tracking: false
            });

        });

    </script>
</body>
</html>
