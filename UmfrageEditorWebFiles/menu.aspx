<%@ Page language="c#" Codebehind="menu.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>menu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV id="m_menu_default" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
				<p class="pagename" align="center">Navigation</p>
				<A class="menu" href="default.aspx" target="_parent">Startseite </A>
			</DIV>
			<DIV id="m_menu_registrieren" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="registrieren.aspx" target="_parent">Registrieren</A></DIV>
			<DIV id="m_menu_admin" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="administration.aspx" target="_parent">Administration</A></DIV>
			<DIV id="m_menu_user" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="defaultuser.aspx" target="_parent">User 
					Profil</A><BR>
			</DIV>
		</form>
	</body>
</HTML>
