<%@ Page language="c#" Codebehind="fragedarstellung.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.fragedarstellung" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fragedarstellung</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="styles.css" rel="stylesheet" type="text/css">
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
								<td vAlign="top" align="left" width="120">
									<TABLE id="Table2" cellSpacing="0" cellPadding="5" width="100%" border="0">
										<TR>
											<TD>
												<DIV id="m_menu_default" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<P class="pagename" align="center">Navigation</P>
													<A class="menu" href="default.aspx" target="_parent">Startseite </A>
												</DIV>
												<DIV id="m_menu_registrieren" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="registrieren.aspx" target="_parent">Registrieren</A>
												</DIV>
												<DIV id="m_menu_admin" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="administration.aspx" target="_parent">Administration</A>
												</DIV>
												<DIV class="menu" id="m_menu_user" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout"><A class="menu" href="defaultuser.aspx" target="_parent">User 
														Profil</A>
												</DIV>
												<BR>
												<DIV id="m_menu_debug" style="WIDTH: 120px" runat="server" ms_positioning="FlowLayout">
													<P class="pagename" align="center">Debug Navigation</P>
													<P><A class="menu" href="administration.aspx" target="_parent">administration</A><BR>
														<A class="menu" href="antworten.aspx" target="_parent">antworten</A><BR>
														<A class="menu" href="default.aspx" target="_parent">default</A><BR>
														<A class="menu" href="defaultuser.aspx" target="_parent">defaultuser</A><BR>
														<A class="menu" href="ergebnisse.aspx.cs" target="_parent">ergebnisse</A><BR>
														<A class="menu" href="fragedarstellung.aspx" target="_parent">fragedarstellung</A><BR>
														<A class="menu" href="login.aspx" target="_parent">login</A><BR>
														<A class="menu" href="loginstatus.aspx" target="_parent">loginstatus</A><BR>
														<A class="menu" href="registrieren.aspx" target="_parent">registrieren</A><BR>
														<A class="menu" href="umfrageergebnisse.aspx" target="_parent">umfrageergebnisse</A><BR>
														<A class="menu" href="umfrageerstellen.aspx" target="_parent">umfrageerstellen</A>
													</P>
												</DIV>
											</TD>
										</TR>
									</TABLE>
								</td>
								<TD vAlign="top" align="left">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="HEIGHT: 18px">
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
												<DIV id="m_pnUmfrageTitel" style="WIDTH: 550px; HEIGHT: 100px" runat="server" ms_positioning="FlowLayout">
													<P id="P1"></P>
													<FONT size="3"></FONT>
													<DIV id="m_lbUmfrageTitel" style="DISPLAY: inline; WIDTH: 100%; HEIGHT: 15px" align="center"
														runat="server" ms_positioning="FlowLayout"></DIV>
													<P></P>
													<DIV id="m_lbComment" style="DISPLAY: inline; WIDTH: 100%; HEIGHT: 15px" align="center"
														runat="server" ms_positioning="FlowLayout"></DIV>
												</DIV>
											</TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
