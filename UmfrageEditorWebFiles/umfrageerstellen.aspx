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
								<td vAlign="top" align="left" width="120"><IFRAME id="menu" style="WIDTH: 122px; HEIGHT: 450px" tabIndex="1" hspace="5" src="menu.aspx"
										frameBorder="0" width="120" scrolling="no"></IFRAME>
								</td>
								<TD vAlign="top" align="left">
									<DIV id="m_pnUmfrageTitel" style="WIDTH: 600px; POSITION: relative; HEIGHT: 248px" runat="server"
										ms_positioning="GridLayout"><asp:label id="m_lbTitle" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server">Titel</asp:label><asp:label id="m_lbComment" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 128px"
											runat="server">Kurzbeschreibung</asp:label><asp:textbox id="m_txtTitel" style="Z-INDEX: 103; LEFT: 128px; POSITION: absolute; TOP: 80px"
											runat="server" Width="393px"></asp:textbox><asp:button id="m_btnTitelUebernehmen" style="Z-INDEX: 104; LEFT: 376px; POSITION: absolute; TOP: 192px"
											runat="server" Text="Übernehmen"></asp:button><asp:checkbox id="m_chbOnline" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 200px"
											runat="server" Text="Umfrage online stellen"></asp:checkbox><asp:textbox id="m_txtComment" style="Z-INDEX: 106; LEFT: 128px; POSITION: absolute; TOP: 120px"
											runat="server" Width="392px"></asp:textbox><asp:label id="m_lbHeadline" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 24px"
											runat="server">Neue Umfrage Erstellen</asp:label></DIV>
									<TABLE id="m_tblFragen" style="WIDTH: 600px; HEIGHT: 57px" cellSpacing="1" cellPadding="1"
										width="600" border="0" runat="server">
										<TR>
											<TD colSpan="2"><asp:datagrid id="m_dgFragen" runat="server" AutoGenerateColumns="False" GridLines="None">
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
											<TD style="WIDTH: 109px"><asp:button id="m_btnLoeschen" runat="server" Text="Löschen"></asp:button></TD>
											<TD><asp:button id="m_btnBearbeiten" runat="server" Width="96px" Text="Bearbeiten"></asp:button></TD>
										</TR>
									</TABLE>
									<DIV id="m_pnFrageErstellen" style="WIDTH: 100%; POSITION: relative; HEIGHT: 186px" runat="server"
										ms_positioning="GridLayout"><asp:label id="m_lbFrage" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server">Frage</asp:label><asp:textbox id="m_txtFrageTitel" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 24px"
											runat="server" Width="424px"></asp:textbox><asp:radiobutton id="m_rdbTextfrage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 72px"
											runat="server" Text="Text-Frage" GroupName="frageart" Checked="True" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="m_rdbUndFrage" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 104px"
											runat="server" Text="Und-Frage (mehrfachauswahl möglich)" GroupName="frageart" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="m_rdbOderFrage" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 136px"
											runat="server" Text="Oder-Frage (keine Mehrfachauswahl)" GroupName="frageart" AutoPostBack="True"></asp:radiobutton></DIV>
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
											<TD colSpan="2"><asp:datagrid id="m_dgAntwErstellen" runat="server" AutoGenerateColumns="False" GridLines="None"
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
											<TD style="WIDTH: 447px"><asp:linkbutton id="m_lnkbMehrAntw" runat="server">mehr Antwortmöglichkeiten</asp:linkbutton></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<DIV id="m_pnFrageUebernehmen" style="WIDTH: 100%; POSITION: relative; HEIGHT: 74px"
										runat="server" ms_positioning="GridLayout"><asp:button id="m_btnFrageUebernehmen" style="Z-INDEX: 101; LEFT: 376px; POSITION: absolute; TOP: 24px"
											runat="server" Text="Übernehmen"></asp:button></DIV>
									<DIV id="m_pnNeueFrage" style="WIDTH: 600px; POSITION: relative; HEIGHT: 88px" runat="server"
										ms_positioning="GridLayout"><asp:button id="m_btnFertig" style="Z-INDEX: 102; LEFT: 448px; POSITION: absolute; TOP: 32px"
											runat="server" Text="Fertig"></asp:button><asp:linkbutton id="m_lnkbNeueFrage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 40px"
											runat="server">neue Frage erstellen</asp:linkbutton></DIV>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
