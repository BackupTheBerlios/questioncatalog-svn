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
				<A href="#" target="_parent">
					<asp:linkbutton id="m_menu_logout" runat="server" CssClass="menu">Logout</asp:linkbutton></A></DIV>
			<BR>
			<DIV id="m_menu_debug" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
				<P class="pagename" align="center">Debug Navigation</P>
				<p>
					<A class="menu" href="administration.aspx" target="_parent">administration</A><br>
					<a href="antworten.aspx" target="_parent" class="menu">antworten</a><br>
					<a href="default.aspx" target="_parent" class="menu">default</a><br>
					<a href="defaultuser.aspx" target="_parent" class="menu">defaultuser</a><br>
					<a href="ergebnisse.aspx.cs" target="_parent" class="menu">ergebnisse</a><br>
					<a href="fragedarstellung.aspx" target="_parent" class="menu">fragedarstellung</a>
					<br>
					<a href="login.aspx" target="_parent" class="menu">login</a><br>
					<a href="loginstatus.aspx" target="_parent" class="menu">loginstatus</a><br>
					<a href="registrieren.aspx" target="_parent" class="menu">registrieren</a><br>
					<a href="umfrageergebnisse.aspx" target="_parent" class="menu">umfrageergebnisse</a><br>
					<a href="umfrageerstellen.aspx" target="_parent" class="menu">umfrageerstellen</a>
				</p>
			</DIV>
		</form>
	</body>
</HTML>
