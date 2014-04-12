<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuStrip.ascx.cs" Inherits="HIS.UserControl.MenuStrip" %>
<script language="javascript" type="text/javascript">
    function fnSetStyle(url, ctrl, groupID) {
        window.location.href = url; //+"?ctrl="+ctrl.toString();  
    }
    function on_mousehover(ctrl) {
        var cname = ctrl.className;
        if (cname == 'mainmenu')
            ctrl.className = 'mainmenuHover';
    }
    function on_mouseout(ctrl) {
        var cname = ctrl.className;
        if (cname == 'mainmenuHover')
            ctrl.className = 'mainmenu';
    }
</script>
<asp:Table Width="100%" CellSpacing="0" EnableViewState="true" CellPadding="0" ID="mainTable"
    runat="server" Height="10px">
    <asp:TableFooterRow ID="mainRow" runat="server">
    </asp:TableFooterRow>
</asp:Table>
