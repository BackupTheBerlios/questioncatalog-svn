<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
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
								<td vAlign="top" align="left" width="120">
									<p class="pagename" align="center"><strong>Startseite</strong></p>
									<DIV id="menu_user" runat="server" ms_positioning="FlowLayout">
										<P><asp:hyperlink class="menu" id="lnkHome" runat="server" NavigateUrl="default.aspx">Startseite</asp:hyperlink><br>
											<asp:hyperlink class="menu" id="lnkLog" runat="server" NavigateUrl="registrieren.aspx">Login</asp:hyperlink><BR>
											<asp:hyperlink class="menu" id="lnkVerwaltung" runat="server" NavigateUrl="administration.aspx">Verwaltung</asp:hyperlink></P>
									</DIV>
								</td>
								<TD vAlign="top" align="left"></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
