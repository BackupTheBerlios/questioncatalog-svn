<%@ Page language="c#" Codebehind="registrieren.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.registrieren" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>registrieren</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="712" border="0">
				<tr vAlign="bottom" align="left">
					<td colSpan="2" height="130"><IMG height="130" src="images/top_bar.gif" width="712"></td>
				</tr>
				<tr>
					<td vAlign="top" align="left" width="21"><IMG height="296" src="images/side_bar.gif" width="21">
					</td>
					<td vAlign="top" align="left" width="691">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" align="left" width="120"><IFRAME id="menu" tabIndex="1" hspace="10" src="menu.aspx" frameBorder="0" width="120" scrolling="no"></IFRAME>
								</td>
								<TD vAlign="top" align="left">
									<P></P>
									<DIV id="lbAusgabe" style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" runat="server"
										ms_positioning="FlowLayout">Ausgabe</DIV>
									<asp:Label id="lbLoginStatus" style="Z-INDEX: 108; LEFT: 376px; POSITION: absolute; TOP: 584px"
										runat="server"></asp:Label>
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="defaultuser.aspx">HyperLink</asp:HyperLink>
									<P></P>
									<P>
										<asp:Label id="Label1" runat="server">Benutzername</asp:Label><BR>
										<asp:TextBox id="txtBenutzername" runat="server"></asp:TextBox></P>
									<P>
										<asp:Label id="Label2" runat="server">Passwort</asp:Label><BR>
										<asp:TextBox id="txtPasswort" runat="server"></asp:TextBox></P>
									<P><INPUT id="btnRegistrieren" type="submit" value="Registrieren" name="Submit1" runat="server">
										<asp:Button id="btnLogin" runat="server" Text="Login"></asp:Button></P>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
