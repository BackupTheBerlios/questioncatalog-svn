<%@ Page language="c#" Codebehind="defaultuser.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.defaultuser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>defaultuser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	    <link href="styles.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
	<FORM id="Form1" method="post" runat="server">
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
							<td width="120" align="left" valign="top"><p align="center" class="pagename"><strong>Startseite</strong></p>
								<DIV id="menu_user" runat="server" ms_positioning="FlowLayout">
									<P>
										<asp:HyperLink class="menu" id="lnkHome" runat="server" NavigateUrl="default.aspx">Startseite</asp:HyperLink>
										<br>
										<asp:HyperLink class="menu" id="lnkLog" runat="server" NavigateUrl="registrieren.aspx">Login</asp:HyperLink><BR>
										<asp:HyperLink class="menu" id="lnkVerwaltung" runat="server" NavigateUrl="administration.aspx">Verwaltung</asp:HyperLink>
									</P>
								</DIV>
							</td>
							<TD align="left" valign="top">
								<DIV id="gridMain" style="WIDTH: 100%; POSITION: relative; HEIGHT: 256px" ms_positioning="GridLayout">
										<asp:Label id="m_lbLoginInfo" style="Z-INDEX: 101; LEFT: 368px; POSITION: absolute; TOP: 8px"
											runat="server">Sie sind eingeloggt als </asp:Label>
										<asp:Label id="m_lbUserName" runat="server"></asp:Label>
										<TABLE id="m_tblUmfragenListe" cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
											<TR>
												<TD colSpan="2">
													<asp:CheckBoxList id="m_chblUmfragenListe" runat="server"></asp:CheckBoxList></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 109px">
													<asp:Button id="m_btnLoeschen" runat="server" Text="L�schen"></asp:Button></TD>
												<TD>
													<asp:Button id="m_btnBearbeiten" runat="server" Text="Bearbeiten"></asp:Button></TD>
											</TR>
										</TABLE>
										<DIV id="m_pnUmfrageNeu" style="WIDTH: 269px; POSITION: relative; HEIGHT: 64px" align="left"
											ms_positioning="GridLayout" runat="server">
											<asp:Button id="m_btnUmfrageNeu" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 16px"
												runat="server" Text="neue Umfrage erstellen" Width="232px"></asp:Button></DIV>
								</DIV>
							</TD>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</FORM>
	</body>
</HTML>
