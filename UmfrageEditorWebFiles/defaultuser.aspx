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
								<td width="120" align="left" valign="top"><IFRAME id="menu" style="WIDTH: 122px; HEIGHT: 450px" tabIndex="1" hspace="5" src="menu.aspx"
										frameBorder="0" width="120" scrolling="no"></IFRAME>
								</td>
								<TD align="left" valign="top">
									<asp:Label id="m_lbLoginInfo" runat="server">Sie sind eingeloggt als </asp:Label>
									<asp:Label id="m_lbUserName" runat="server"></asp:Label>
									<TABLE id="m_tblUmfragenListe" cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
										<TR>
											<TD colSpan="2">
												<asp:CheckBoxList id="m_chblUmfragenListe" runat="server"></asp:CheckBoxList></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 109px">
												<asp:Button id="m_btnLoeschen" runat="server" Text="Löschen" Width="100px"></asp:Button></TD>
											<TD>
												<asp:Button id="m_btnBearbeiten" runat="server" Text="Bearbeiten" Width="100px"></asp:Button></TD>
										</TR>
									</TABLE>
									<DIV id="m_pnUmfrageNeu" style="WIDTH: 275px; POSITION: relative; HEIGHT: 71px" align="left"
										runat="server" ms_positioning="GridLayout">
										<asp:LinkButton id="m_lnkbUmfrageNeu" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 24px"
											runat="server">neue Umfrage erstellen</asp:LinkButton></DIV>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
