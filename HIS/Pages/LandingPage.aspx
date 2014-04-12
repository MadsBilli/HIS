<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LandingPage.aspx.cs" Inherits="HIS.Pages.LandingPage" EnableViewStateMac="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="float: left;">
        <ul id="nav">
            <div runat="server" id="main">
            </div>
        </ul>
    </div>
    <div>
        <%--<div style="border: 2px none black; float: left; height: 108%; width: 680px;">
            <h1 style="color: Red; width: 600px;">
                Announcements</h1>
            <p style="color: #c00; padding: 40px; padding-left: 90px; font-size: medium;">
                <span>welcome to Harmony In-House System</span></p>
        </div>--%>
        <table style="width: 600px; height: 100px">
            <tr>
                <td>
                    Announcements
                </td>
            </tr>
            </table>
    </div>
    <div style="float: right; width: 300px;">
        <div class="example">
        </div>
    </div>
    <link rel="stylesheet" media="screen" type="text/css" href="../App_Themes/Theme/calendar/kalendar.css" />
    <script type="text/javascript" src="../App_Themes/Theme/calendar/jquery-2.0.3.min.js"></script>
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
</asp:Content>
