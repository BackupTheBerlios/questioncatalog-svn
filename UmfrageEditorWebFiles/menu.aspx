<%@ Page language="c#" Codebehind="menu.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>menu</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<STYLE></STYLE>
</HEAD>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
<DIV id=menu_user 
style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100px; POSITION: absolute; TOP: 8px; HEIGHT: 100px" 
runat="server" ms_positioning="FlowLayout">
<P><BR><BR>
<asp:HyperLink class=menu id=lnkLog runat="server" NavigateUrl="registrieren.aspx">Login</asp:HyperLink><BR>
<asp:HyperLink class=menu id=lnkVerwaltung runat="server" NavigateUrl="administration.aspx">Verwaltung</asp:HyperLink></P></DIV>&nbsp;

     </form>
	
  </body>
</HTML>
