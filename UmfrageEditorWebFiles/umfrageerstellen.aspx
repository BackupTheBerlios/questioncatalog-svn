<%@ Page language="c#" Codebehind="umfrageerstellen.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.umfrageerstellen" smartNavigation="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%#PageTitle%>
		</title>
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
								<td vAlign="top" align="left" width="120">
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
								</td>
								<TD vAlign="top" align="left">
									<P>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="HEIGHT: 18px">
													<DIV align="right">
														<DIV id="m_login" style="HEIGHT: 18px" align="right" runat="server" ms_positioning="FlowLayout">
															<asp:Label id="lbLoginMessage" runat="server" ForeColor="Red" CssClass="login"></asp:Label>&nbsp;&nbsp;
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
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="m_pnUmfrageTitel" style="WIDTH: 600px; POSITION: relative; HEIGHT: 264px" runat="server"
														ms_positioning="GridLayout">
														<asp:label id="m_lbTitle" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server">Titel</asp:label>
														<asp:label id="m_lbComment" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 128px"
															runat="server">Kurzbeschreibung</asp:label>
														<asp:textbox id="m_txtTitel" style="Z-INDEX: 103; LEFT: 128px; POSITION: absolute; TOP: 80px"
															runat="server" Width="393px"></asp:textbox>
														<asp:button id="m_btnTitelUebernehmen" style="Z-INDEX: 104; LEFT: 376px; POSITION: absolute; TOP: 208px"
															runat="server" Text="Übernehmen"></asp:button>
														<asp:checkbox id="m_chbOnline" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 208px"
															runat="server" Text="Umfrage online stellen"></asp:checkbox>
														<asp:textbox id="m_txtComment" style="Z-INDEX: 106; LEFT: 128px; POSITION: absolute; TOP: 120px"
															runat="server" Width="392px"></asp:textbox>
														<asp:label id="m_lbHeadline" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 24px"
															runat="server">Neue Umfrage Erstellen</asp:label>
														<asp:RequiredFieldValidator id="m_valTitel" style="Z-INDEX: 108; LEFT: 536px; POSITION: absolute; TOP: 88px"
															runat="server" Width="8px" EnableClientScript="False" ControlToValidate="m_txtTitel" ErrorMessage="!"></asp:RequiredFieldValidator>
														<asp:RequiredFieldValidator id="m_valComment" style="Z-INDEX: 109; LEFT: 536px; POSITION: absolute; TOP: 128px"
															runat="server" EnableClientScript="False" ControlToValidate="m_txtComment" ErrorMessage="!"></asp:RequiredFieldValidator>
														<asp:Label id="m_lbValidatorMessageTitel" style="Z-INDEX: 110; LEFT: 128px; POSITION: absolute; TOP: 168px"
															runat="server" Visible="False" ForeColor="Red">Bitte füllen Sie das markierte Feld aus!</asp:Label></DIV>
													<TABLE id="m_tblFragen" style="WIDTH: 600px; HEIGHT: 57px" cellSpacing="1" cellPadding="1"
														width="600" border="0" runat="server">
														<TR>
															<TD colSpan="2">
																<asp:datagrid id="m_dgFragen" runat="server" GridLines="None" AutoGenerateColumns="False">
																	<Columns>
																		<asp:BoundColumn DataField="FrageID"></asp:BoundColumn>
																		<asp:TemplateColumn>
																			<ItemTemplate>
																				<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="Text"></asp:BoundColumn>
																		<asp:BoundColumn Visible="False" DataField="Frageart"></asp:BoundColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 100px">
																<asp:button id="m_btnLoeschen" runat="server" Text="Löschen" CausesValidation="False"></asp:button></TD>
															<TD>
																<asp:button id="m_btnBearbeiten" runat="server" Width="96px" Text="Bearbeiten" CausesValidation="False"></asp:button></TD>
														</TR>
													</TABLE>
													<DIV id="m_pnFrageErstellen" style="WIDTH: 100%; POSITION: relative; HEIGHT: 218px" runat="server"
														ms_positioning="GridLayout">
														<asp:label id="m_lbFrage" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server">Frage</asp:label>
														<asp:textbox id="m_txtFrageTitel" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 24px"
															runat="server" Width="424px"></asp:textbox>
														<asp:radiobutton id="m_rdbTextfrage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 112px"
															runat="server" Text="Text-Frage" AutoPostBack="True" Checked="True" GroupName="frageart"></asp:radiobutton>
														<asp:radiobutton id="m_rdbUndFrage" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 144px"
															runat="server" Text="Und-Frage (mehrfachauswahl möglich)" AutoPostBack="True" GroupName="frageart"></asp:radiobutton>
														<asp:radiobutton id="m_rdbOderFrage" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 176px"
															runat="server" Text="Oder-Frage (keine Mehrfachauswahl)" AutoPostBack="True" GroupName="frageart"></asp:radiobutton>
														<asp:RequiredFieldValidator id="m_valFrageTitel" style="Z-INDEX: 106; LEFT: 536px; POSITION: absolute; TOP: 32px"
															runat="server" EnableClientScript="False" ControlToValidate="m_txtFrageTitel" ErrorMessage="!"></asp:RequiredFieldValidator>
														<asp:Label id="m_lbValidatorMessageFrage" style="Z-INDEX: 107; LEFT: 96px; POSITION: absolute; TOP: 72px"
															runat="server" Visible="False" ForeColor="Red">Bitte füllen Sie das markierte Feld aus!</asp:Label></DIV>
													<TABLE id="m_tblAntwortmoeglErstellen" style="WIDTH: 600px; HEIGHT: 84px" cellSpacing="1"
														cellPadding="1" width="600" border="0" runat="server">
														<TR>
															<TD colSpan="2">Antwortmöglickeiten vorgeben:</TD>
														</TR>
														<TR>
															<TD colSpan="2">
																<asp:Label id="m_lbWarningAlreadyAnswered" runat="server" ForeColor="Red">Falls zu dieser Umfrage bereits Antworten  bestehen, können Änderungen an der Reihenfolge der Antwortmöglichkeiten falsche Zuordnugen von Antworten zur Folge haben!</asp:Label></TD>
														</TR>
														<TR>
															<TD colSpan="2">
																<asp:datagrid id="m_dgAntwErstellen" runat="server" GridLines="None" AutoGenerateColumns="False"
																	BorderWidth="0px">
																	<Columns>
																		<asp:BoundColumn></asp:BoundColumn>
																		<asp:TemplateColumn>
																			<ItemTemplate>
																				<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 447px">
																<asp:linkbutton id="m_lnkbMehrAntw" runat="server" CausesValidation="False">mehr Antwortmöglichkeiten</asp:linkbutton></TD>
															<TD></TD>
														</TR>
													</TABLE>
													<DIV id="m_pnFrageUebernehmen" style="WIDTH: 100%; POSITION: relative; HEIGHT: 74px"
														runat="server" ms_positioning="GridLayout">
														<asp:button id="m_btnFrageUebernehmen" style="Z-INDEX: 101; LEFT: 376px; POSITION: absolute; TOP: 24px"
															runat="server" Text="Übernehmen"></asp:button></DIV>
													<DIV id="m_pnNeueFrage" style="WIDTH: 600px; POSITION: relative; HEIGHT: 88px" runat="server"
														ms_positioning="GridLayout">
														<asp:button id="m_btnFertig" style="Z-INDEX: 102; LEFT: 448px; POSITION: absolute; TOP: 32px"
															runat="server" Text="Fertig"></asp:button>
														<asp:linkbutton id="m_lnkbNeueFrage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 40px"
															runat="server" CausesValidation="False">neue Frage erstellen</asp:linkbutton></DIV>
												</TD>
											</TR>
										</TABLE>
									</P>
									<P>&nbsp;</P>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
