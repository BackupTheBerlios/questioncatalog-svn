<%@ Page language="c#" Codebehind="registrieren.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.registrieren" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>registrieren</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtBenutzername" style="Z-INDEX: 101; LEFT: 368px; POSITION: absolute; TOP: 304px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtPasswort" style="Z-INDEX: 102; LEFT: 368px; POSITION: absolute; TOP: 392px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 376px; POSITION: absolute; TOP: 256px" runat="server">Benutzername</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 376px; POSITION: absolute; TOP: 352px" runat="server">Passwort</asp:Label><INPUT id="btnRegistrieren" style="Z-INDEX: 105; LEFT: 376px; POSITION: absolute; TOP: 464px"
				type="submit" value="Registrieren" name="Submit1" runat="server">
			<DIV id="lbAusgabe" style="DISPLAY: inline; Z-INDEX: 106; LEFT: 64px; WIDTH: 70px; POSITION: absolute; TOP: 72px; HEIGHT: 15px"
				runat="server" ms_positioning="FlowLayout">Ausgabe</DIV>
		</form>
	</body>
</HTML>
