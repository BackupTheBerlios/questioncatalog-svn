<%@ Page language="c#" Codebehind="administration.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.administration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>administration</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="styles.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="712" border="0" cellpadding="0" cellspacing="0">
				<tr align="left" valign="bottom">
					<td height="130" colspan="2"><img src="images/top_bar.gif" width="712" height="130"></td>
				</tr>
				<tr>
					<td width="21" align="left" valign="top"><img src="images/side_bar.gif" width="21" height="296">
					</td>
					<td width="691" align="left" valign="top">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="120" align="left" valign="top"><DIV id="menu_user" runat="server" ms_positioning="FlowLayout">
										<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
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
									</DIV>
								</td>
								<TD align="left" valign="top">&nbsp;
									<DIV id="m_login" style="HEIGHT: 18px" align="right" runat="server" ms_positioning="FlowLayout">
										<asp:Label id="lbLoginMessage" runat="server" ForeColor="Red" CssClass="login"></asp:Label>&nbsp;&nbsp;
										<SPAN class="login">Benutzername</SPAN>
										<asp:textbox id="txtBenutzername" runat="server" BorderWidth="1px" Width="60px" BorderStyle="Solid"
											Height="16px" Font-Size="10px" MaxLength="20"></asp:textbox>&nbsp;&nbsp; <SPAN class="login">
											Passwort</SPAN>
										<asp:textbox id="txtPasswort" runat="server" BorderWidth="1px" Width="60px" BorderStyle="Solid"
											Height="16px" Font-Size="10px" MaxLength="20" TextMode="Password"></asp:textbox>&nbsp;&nbsp;
										<asp:LinkButton id="LinkLogin" runat="server" CssClass="function">Login</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</DIV>
									<DIV align="right">
										<DIV id="m_logout" style="HEIGHT: 18px" runat="server" ms_positioning="FlowLayout">
											<asp:Label id="lbLoginStatus" runat="server" CssClass="login"></asp:Label>
											<asp:LinkButton id="LinkLogout" runat="server" CssClass="function">Logout</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</DIV>
										<TABLE id="m_tblRegisterCards" cellSpacing="1" cellPadding="1" width="600" border="0" runat="server">
											<TR>
												<TD style="WIDTH: 120px">
													<asp:Button id="m_btnBenutzer" runat="server" Text="Benutzer" BackColor="#4263C6" Width="100%"
														BorderWidth="1px" ForeColor="White" BorderColor="Silver"></asp:Button></TD>
												<TD style="WIDTH: 120px">
													<asp:Button id="m_btnUmfragen" runat="server" Text="Umfragen" BackColor="#4263C6" Width="100%"
														BorderWidth="1px" ForeColor="White" BorderColor="Silver"></asp:Button></TD>
												<TD></TD>
											</TR>
										</TABLE>
										<TABLE id="m_tblBenutzer" cellSpacing="0" cellPadding="1" width="600" border="1" runat="server">
											<TR>
												<TD borderColor="#c0c0c0" colSpan="2">
													<asp:DataGrid id="m_dgBenutzer" runat="server" BorderWidth="0px" AutoGenerateColumns="False" GridLines="None">
														<Columns>
															<asp:BoundColumn DataField="UserID"></asp:BoundColumn>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Name"></asp:BoundColumn>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 100px" borderColor="#c0c0c0">
													<asp:Button id="m_btnBenutzerLoeschen" runat="server" Text="Löschen" Width="90px"></asp:Button></TD>
											</TR>
										</TABLE>
										<TABLE id="m_tblUmfragen" borderColor="silver" cellSpacing="1" cellPadding="1" width="600"
											border="1" runat="server">
											<TR>
												<TD>
													<asp:DataGrid id="m_dgUmfragen" runat="server" BorderWidth="0px" AutoGenerateColumns="False" GridLines="None">
														<Columns>
															<asp:BoundColumn DataField="UmfrageID"></asp:BoundColumn>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Titel"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
											<TR>
												<TD>
													<asp:Button id="m_btnUmfrageLoeschen" runat="server" Width="90px" Text="Löschen"></asp:Button></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
