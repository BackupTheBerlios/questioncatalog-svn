<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Startseite</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript">
<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
//-->
		</script>
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
								<td vAlign="top" align="left" width="120"><table width="100%" border="0" cellspacing="0" cellpadding="5">
										<tr>
											<td>
												<DIV id="m_menu_default" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<p class="pagename" align="center">Navigation</p>
													<A class="menu" href="default.aspx" target="_parent">Startseite </A>
												</DIV>
												<DIV id="m_menu_registrieren" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<A class="menu" href="registrieren.aspx" target="_parent">Registrieren</A>
												</DIV>
												<DIV id="m_menu_admin" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<A class="menu" href="administration.aspx" target="_parent">Administration</A>
												</DIV>
												<DIV class="menu" id="m_menu_user" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<A class="menu" href="defaultuser.aspx" target="_parent">User Profil</A>
												</DIV>
												<br>
												<DIV id="m_menu_debug" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<P class="pagename" align="center">Debug Navigation</P>
													<p>
														<A class="menu" href="administration.aspx" target="_parent">administration</A><br>
														<a href="antworten.aspx" target="_parent" class="menu">antworten</a><br>
														<a href="default.aspx" target="_parent" class="menu">default</a><br>
														<a href="defaultuser.aspx" target="_parent" class="menu">defaultuser</a><br>
														<a href="ergebnisse.aspx.cs" target="_parent" class="menu">ergebnisse</a><br>
														<a href="fragedarstellung.aspx" target="_parent" class="menu">fragedarstellung</a><br>
														<a href="login.aspx" target="_parent" class="menu">login</a><br>
														<a href="loginstatus.aspx" target="_parent" class="menu">loginstatus</a><br>
														<a href="registrieren.aspx" target="_parent" class="menu">registrieren</a><br>
														<a href="umfrageergebnisse.aspx" target="_parent" class="menu">umfrageergebnisse</a><br>
														<a href="umfrageerstellen.aspx" target="_parent" class="menu">umfrageerstellen</a>
													</p>
												</DIV>
											</td>
										</tr>
									</table>
								</td>
								<TD style="HEIGHT: 191px" vAlign="top" align="left" height="191">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td style="HEIGHT: 18px">
												<DIV align="right">
													<DIV id="m_login" style="HEIGHT: 18px" align="right" runat="server" ms_positioning="FlowLayout">
														<asp:Label id="lbLoginMessage" runat="server" CssClass="login" ForeColor="Red"></asp:Label>&nbsp;&nbsp;
														<SPAN class="login">Benutzername</SPAN>
														<asp:textbox id="txtBenutzername" runat="server" Width="60px" BorderWidth="1px" BorderStyle="Solid"
															Height="16px" Font-Size="10px" MaxLength="20"></asp:textbox>&nbsp;&nbsp; <SPAN class="login">
															Passwort</SPAN>
														<asp:textbox id="txtPasswort" runat="server" Width="60px" BorderWidth="1px" BorderStyle="Solid"
															Height="16px" Font-Size="10px" MaxLength="20" TextMode="Password"></asp:textbox>&nbsp;&nbsp;
														<asp:LinkButton id="LinkLogin" runat="server" CssClass="function">Login</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</DIV>
													<DIV align="right">
														<DIV id="m_logout" style="HEIGHT: 18px" runat="server" ms_positioning="FlowLayout">
															<asp:Label id="lbLoginStatus" runat="server" CssClass="login"></asp:Label>
															<asp:LinkButton id="LinkLogout" runat="server" CssClass="function">Logout</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														</DIV>
													</DIV>
												</DIV>
											</td>
										</tr>
										<tr>
											<td align="center">
												<P align="center"><BR>
													<BR>
													Wählen Sie eine Umfrage aus, an der Sie teilnehmen möchten</P>
												<P>
													<asp:DataGrid id="m_dgUmfragen" runat="server" CssClass="text" Width="424px" AutoGenerateColumns="False"
														BorderStyle="None" BorderWidth="0px" GridLines="None">
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="UmfrageID" HeaderText="ID"></asp:BoundColumn>
															<asp:HyperLinkColumn Target="_parent" DataNavigateUrlField="umfrageID" DataNavigateUrlFormatString="fragedarstellung.aspx?uid={0}"
																DataTextField="Titel" HeaderText="Titel der Umfrage"></asp:HyperLinkColumn>
															<asp:BoundColumn DataField="Beschreibung" HeaderText="Beschreibung"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid></P>
											</td>
										</tr>
									</table>
									<p>&nbsp;</p>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
