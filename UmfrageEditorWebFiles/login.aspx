<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV id="m_login" style="HEIGHT: 18px" align="right" runat="server" ms_positioning="FlowLayout">
				<asp:Label id="lbLoginMessage" runat="server" CssClass="login" ForeColor="Red"></asp:Label>&nbsp;&nbsp;
				<span class="login">Benutzername</span>
				<asp:textbox id="txtBenutzername" runat="server" Width="60px" BorderWidth="1px" BorderStyle="Solid" Height="16px" Font-Size="10px" MaxLength="20"></asp:textbox>&nbsp;&nbsp;
				<span class="login">Passwort</span>
				<asp:textbox id="txtPasswort" runat="server" Width="60px" BorderWidth="1px" BorderStyle="Solid" Height="16px" Font-Size="10px" MaxLength="20" TextMode="Password"></asp:textbox>&nbsp;&nbsp;
				<asp:LinkButton id="LinkLogin" runat="server" CssClass="function">Login</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			</DIV>
			<div align="right">
				<DIV id="m_logout" style="HEIGHT: 18px" runat="server" ms_positioning="FlowLayout">
					<asp:Label id="lbLoginStatus" runat="server" CssClass="login"></asp:Label>
					<asp:LinkButton id="LinkLogout" runat="server" CssClass="function">Logout</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				</DIV>
			</div>
		</form>
	</body>
</HTML>
